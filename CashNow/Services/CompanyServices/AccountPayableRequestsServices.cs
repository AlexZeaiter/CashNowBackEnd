using System;
using CashNow.DbContexts;
using CashNow.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashNow.Services.UserServices;

namespace CashNow.Services.CompanyServices
{
    public class AccountPayableRequestsServices
    {
        private readonly AccountPayablesRequestsDbContext _context;
        private readonly CompanyInformationService _companyInformationService;

        public AccountPayableRequestsServices(AccountPayablesRequestsDbContext context, CompanyInformationService companyInformationService)
        {
            _context = context;
            _companyInformationService = companyInformationService;
        }

        private double SettlementValueCalculator(double intialFees, double InstallmentRate, int numberOfInstallments)
        {
            return (((intialFees * (InstallmentRate * (Math.Pow((1 + InstallmentRate), numberOfInstallments)))) / ((Math.Pow((1 + InstallmentRate), numberOfInstallments)) - 1)) * numberOfInstallments);
        }
        public async Task AddAP_RequestData(AP_RequestData ap_RequestData)
        {
            CompanyInformation companyInformation;

            if (ap_RequestData.AccountPayablesRequest.CompanyId != null)
            {
                companyInformation = await _companyInformationService.GetCompanyInformation(ap_RequestData.AccountPayablesRequest.CompanyId);
            }
            else
            {
                return;
            }

            AccountPayablesRequests accountPayablesRequests = ap_RequestData.AccountPayablesRequest;
            AP_OrderDetailsHeader ap_OrderDetailsHeader = ap_RequestData.AP_OrderDetailsHeader;
            //List<AP_OrderDetailsItems> AP_OrderDetailsItems = ap_RequestData.AP_OrderDetailsItemsList;
            APRequestDetails apRequestDetails = ap_RequestData.APRequestDetails;
            BeneficiaryDetails beneficiaryDetails = ap_RequestData.BeneficiaryDetails;
            BeneficiaryInvoiceDetails beneficiaryInvoiceDetails = ap_RequestData.BeneficiaryInvoiceDetails;
            SupportingDocuments supportingDocuments = ap_RequestData.SupportingDocuments;

            if(beneficiaryInvoiceDetails.TotalInvoiceValueIncludesVAT)
            {
                beneficiaryInvoiceDetails.TotalValueToBePaidToBeneficiary = beneficiaryInvoiceDetails.TotalInvoiceValue;
            }
            else
            {
                beneficiaryInvoiceDetails.TotalValueToBePaidToBeneficiary = (float)(beneficiaryInvoiceDetails.TotalInvoiceValue * 1.14);
            }

            if (beneficiaryDetails.IsOTS)
            {
                apRequestDetails.SourcingFees = (float)((beneficiaryInvoiceDetails.TotalValueToBePaidToBeneficiary) * 0.04);
            }

            int daysDiff = ((int)(apRequestDetails.APSettelmentDate - DateTime.Now).TotalDays) + 3;
            double x = daysDiff / 15;
            int numberOfPayments = (int)Math.Round(x);
            float intialFees = (float)((beneficiaryInvoiceDetails.TotalValueToBePaidToBeneficiary * ((1 + companyInformation.CompanyRatePerFiftnCalendarDays) * numberOfPayments)) + companyInformation.CompanyFlatFeesPerInvoice);
            apRequestDetails.MediationFees = intialFees - beneficiaryInvoiceDetails.TotalValueToBePaidToBeneficiary;

            if (apRequestDetails.ChosenPaymentOption == 1)//pay once
            {
                apRequestDetails.SettlementValue = intialFees;
            }
            else if (apRequestDetails.ChosenPaymentOption == 2) // 2 months installments
            {
                //(double)((intialFees * (companyInformation.InstallmentRate * (Math.Pow((double)(1 + companyInformation.InstallmentRate), 2)))) / ((Math.Pow((double)(1 + companyInformation.InstallmentRate), 2)) - 1));
                apRequestDetails.SettlementValue = (float)SettlementValueCalculator(intialFees, (double)companyInformation.InstallmentRate, 2);
            }
            else if (apRequestDetails.ChosenPaymentOption == 3) // 3 months installments
            {
                apRequestDetails.SettlementValue = (float)SettlementValueCalculator(intialFees, (double)companyInformation.InstallmentRate, 3);
            }
            else if (apRequestDetails.ChosenPaymentOption == 6) // 6 months installments
            {
                apRequestDetails.SettlementValue = (float)SettlementValueCalculator(intialFees, (double)companyInformation.InstallmentRate, 6);
            }

            int APRequestId = await AddAP_Request(accountPayablesRequests);

            ap_OrderDetailsHeader.APRequestId = APRequestId;
            apRequestDetails.APRequestId = APRequestId;
            beneficiaryDetails.APRequestId = APRequestId;
            beneficiaryInvoiceDetails.APRequestId = APRequestId;
            supportingDocuments.APRequestId = APRequestId;

            int orderDetailsHeaderId = await AddAP_OrderDetailsHeader(ap_OrderDetailsHeader);

            //foreach(AP_OrderDetailsItems item in AP_OrderDetailsItems)
            //{
            //    item.AP_OrderDetailsHeaderId = orderDetailsHeaderId;

            //    await AddAP_OrderDetailsItems(item);
            //}

            await AddAPRequestDetails(apRequestDetails);
            await AddBeneficiaryDetails(beneficiaryDetails);
            await AddBeneficiaryInvoiceDetails(beneficiaryInvoiceDetails);
            //await AddSupportingDocuments(supportingDocuments);

        }
        public async Task<int> AddAP_Request(AccountPayablesRequests accountPayablesRequests)
        {
            _context.AccountPayablesRequests.Add(accountPayablesRequests);
            await _context.SaveChangesAsync();
            return accountPayablesRequests.APRequestId;
        }
        public async Task<int> AddAP_OrderDetailsHeader(AP_OrderDetailsHeader ap_OrderDetailsHeader)
        {
            _context.AP_OrderDetailsHeader.Add(ap_OrderDetailsHeader);
            await _context.SaveChangesAsync();
            return ap_OrderDetailsHeader.APRequestId;

        }
        public async Task AddAP_OrderDetailsItems(AP_OrderDetailsItems AP_OrderDetailsItems)
        {
            _context.AP_OrderDetailsItems.Add(AP_OrderDetailsItems);
            await _context.SaveChangesAsync();
        }
        public async Task AddAPRequestDetails(APRequestDetails apRequestDetails)
        {
            apRequestDetails.APRequestStatus = "Submitted";
            _context.APRequestDetails.Add(apRequestDetails);
            await _context.SaveChangesAsync();
        }
        public async Task AddBeneficiaryDetails(BeneficiaryDetails beneficiaryDetails)
        {
            _context.BeneficiaryDetails.Add(beneficiaryDetails);
            await _context.SaveChangesAsync();
        }
        public async Task AddBeneficiaryInvoiceDetails(BeneficiaryInvoiceDetails beneficiaryInvoiceDetails)
        {
            _context.BeneficiaryInvoiceDetails.Add(beneficiaryInvoiceDetails);
            await _context.SaveChangesAsync();
        }
        public async Task AddSupportingDocuments(SupportingDocuments supportingDocuments)
        {
            _context.SupportingDocuments.Add(supportingDocuments);
            await _context.SaveChangesAsync();
        }
    }
}
