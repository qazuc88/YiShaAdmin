using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.CoinManage;
using YiSha.Model.Param.CoinManage;
using YiSha.Service.CoinManage;

namespace YiSha.Business.CoinManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-11-30 19:02
    /// 描 述：业务类
    /// </summary>
    public class CoinBLL
    {
        private CoinService coinService = new CoinService();

        #region 获取数据
        public async Task<TData<List<CoinEntity>>> GetList(CoinListParam param)
        {
            TData<List<CoinEntity>> obj = new TData<List<CoinEntity>>();
            obj.Data = await coinService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<CoinEntity>>> GetPageList(CoinListParam param, Pagination pagination)
        {
            TData<List<CoinEntity>> obj = new TData<List<CoinEntity>>();
            obj.Data = await coinService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<CoinEntity>> GetEntity(long id)
        {
            TData<CoinEntity> obj = new TData<CoinEntity>();
            obj.Data = await coinService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(CoinEntity entity)
        {
            TData<string> obj = new TData<string>();
            await coinService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await coinService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
