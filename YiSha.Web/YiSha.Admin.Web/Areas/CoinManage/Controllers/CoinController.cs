using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using YiSha.Util;
using YiSha.Util.Model;
using YiSha.Entity;
using YiSha.Model;
using YiSha.Admin.Web.Controllers;
using YiSha.Entity.CoinManage;
using YiSha.Business.CoinManage;
using YiSha.Model.Param.CoinManage;

namespace YiSha.Admin.Web.Areas.CoinManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-11-30 19:02
    /// 描 述：控制器类
    /// </summary>
    [Area("CoinManage")]
    public class CoinController :  BaseController
    {
        private CoinBLL coinBLL = new CoinBLL();

        #region 视图功能
        [AuthorizeFilter("coin:coin:view")]
        public ActionResult CoinIndex()
        {
            return View();
        }

        public ActionResult CoinForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("coin:coin:search")]
        public async Task<ActionResult> GetListJson(CoinListParam param)
        {
            TData<List<CoinEntity>> obj = await coinBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("coin:coin:search")]
        public async Task<ActionResult> GetPageListJson(CoinListParam param, Pagination pagination)
        {
            TData<List<CoinEntity>> obj = await coinBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<CoinEntity> obj = await coinBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("coin:coin:add,coin:coin:edit")]
        public async Task<ActionResult> SaveFormJson(CoinEntity entity)
        {
            TData<string> obj = await coinBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("coin:coin:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await coinBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
