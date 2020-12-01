using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.CoinManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-11-30 19:02
    /// 描 述：实体类
    /// </summary>
    [Table("base_coin")]
    public class CoinEntity : BaseEntity
    {
        /// <summary>
        /// 币种名称（英文名全称）
        /// </summary>
        /// <returns></returns>
        public string CoinName { get; set; }
        /// <summary>
        /// 白皮书链接
        /// </summary>
        /// <returns></returns>
        public string WhitePaperLink { get; set; }
    }
}
