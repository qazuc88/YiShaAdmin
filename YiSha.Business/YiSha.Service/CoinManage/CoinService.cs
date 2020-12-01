using System;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Data;
using YiSha.Data.Repository;
using YiSha.Entity.CoinManage;
using YiSha.Model.Param.CoinManage;

namespace YiSha.Service.CoinManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-11-30 19:02
    /// 描 述：服务类
    /// </summary>
    public class CoinService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<CoinEntity>> GetList(CoinListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<CoinEntity>> GetPageList(CoinListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<CoinEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<CoinEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(CoinEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                
                await this.BaseRepository().Update(entity);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<CoinEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<CoinEntity, bool>> ListFilter(CoinListParam param)
        {
            var expression = LinqExtensions.True<CoinEntity>();
            if (param != null)
            {
                expression.And(x => x.CoinName.Contains(param.CoinName));
            }
            return expression;
        }
        #endregion
    }
}
