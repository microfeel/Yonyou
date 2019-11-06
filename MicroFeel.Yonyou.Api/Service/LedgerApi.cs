using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroFeel.Yonyou.Api.Service
{
    public class LedgerApi : Api
    {
        /// <summary>
        /// 总账API   9
        /// </summary>
        public LedgerApi() : base("api") { }

        /// <summary>
        /// 凭证 获取凭证列表信息    
        /// </summary>
        /// <param name="billCodeFrom"></param>
        /// <param name="billCodeTo"></param>
        /// <param name="billDataFrom"></param>
        /// <param name="billDataTo"></param>
        /// <param name="cBill"></param>
        /// <param name="dsSequence"></param>
        /// <param name="cnoId"></param>
        /// <param name="coutnoId"></param>
        /// <param name="csign"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Voucher>> Batch_get_voucherlistAsync(string billCodeFrom, string billCodeTo, string billDataFrom, string billDataTo, string cBill, int dsSequence, string cnoId, string coutnoId, string csign)
        {
            var req = new VoucherListRequest(await GetRequestTypeAsync<CallerRequest>())
            {
                Bill_code_from = billCodeFrom,
                Bill_code_to = billCodeTo,
                Bill_date_from = billDataFrom,
                Bill_date_to = billDataTo,
                Cbill = cBill,
                Ds_sequence = dsSequence,
                Cno_id = cnoId,
                Coutno_id = coutnoId,
                Csign = csign
            };
            var result = await CallAsync<DbRequest, VoucherListResult>(req);
            return result.Voucherlist.Vouchers;
        }
        /// <summary>
        /// 批量获取凭证列表详情  
        /// </summary> 
        /// <return></return>
        public async Task<IEnumerable<VoucherDetail>> Batch_get_voucherdetailsAsync(string codeBegin, string codeEnd, int dsSequence, bool bdelete, string coutnoId, DateTime dataBegin, DateTime dataEnd)
        {
            var req = new VoucherDetailRequest(await GetRequestTypeAsync<CallerRequest>())
            {
                Ds_sequence = dsSequence,
                Code_begin = codeBegin,
                Code_end = codeEnd,
                Coutno_id = coutnoId,
                Bdelete = bdelete,
                Date_begin = dataBegin,
                Date_end = dataEnd,
            };
            var result = await CallAsync<VoucherDetailRequest, VoucherDetailResult>(req);
            return result.Voucherdetails;
        }
        /// <summary>
        /// 获取凭证详情列表    
        /// </summary> 
        /// <return></return>
        public object Batch_get_voucherdetaillist() { return null; }
        /// <summary>
        /// 凭证作废    
        /// </summary> 
        /// <return></return>
        public object Cancel_voucher() { return null; }
        /// <summary>
        /// 新增一张凭证  
        /// </summary> 
        /// <return></return>
        public object Add_voucher() { return null; }
        /// <summary>
        /// 帐套启用会计区间    获取启用的会计期间 
        /// </summary> 
        /// <return></return>
        public object Batch_get_startperiod() { return null; }
        /// <summary>
        /// 总账结账状态  批量获取总账结账状态 
        /// </summary> 
        /// <return></return>
        public object Batch_get_mendglgz() { return null; }
        /// <summary>
        /// 科目总账    批量获取科目总账信息 
        /// </summary> 
        /// <return></return>
        public object Batch_get_accountsum() { return null; }
        /// <summary>
        /// 辅助总账    批量获取辅助总账信息 
        /// </summary> 
        /// <return></return>
        public object Batch_get_accountass() { return null; }


    }
}
