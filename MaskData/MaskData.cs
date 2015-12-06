using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//可參考http://www.dotblogs.com.tw/andytsao701/archive/2014/06/08/145432.aspx

namespace MaskData
{
    /// <summary>
    /// 遮罩資料類型
    /// </summary>
    public enum MaskType
    {
        MobileNumberTW,
        CreaditCard16,
        twID,
        cnID,
        tele,
        CHTaddr,
        name,
        birth,
        email
    }

    /// <summary>
    /// 遮罩類別
    /// </summary>
    public class MaskInfo
    {
        #region Private Params
        private string rtn;
        private string maskstr;
        private string maskchar;
        private char _maskChar;
        private string _result;
        #endregion
        #region Public Params
        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }
        #endregion

        public MaskInfo(char 遮罩字元)
        {
            _maskChar = 遮罩字元;
        }

        /// <summary>
        /// 遮罩方法，輸入字串、型態，輸出結果
        /// </summary>
        /// <param name="要遮罩的字串">X123456787</param>
        /// <param name="遮罩類型">MaskType.twID</param>
        /// <returns>輸出結果，也可透過物件屬性Result取得</returns>
        public string getMaskValue(string inputValue, MaskType maskDataType)
        {
            string Output = string.Empty;
            switch (maskDataType)
            {
                case MaskType.MobileNumberTW:
                    return getMaskMobileNumberTW(inputValue);
                case MaskType.CreaditCard16:
                    return getMaskCreaditCard16(inputValue);
                case MaskType.twID:
                    return getMaskTwID(inputValue);
                case MaskType.cnID:
                    return getMaskCnID(inputValue);
                case MaskType.tele:
                    return getMaskTele(inputValue);
                case MaskType.CHTaddr:
                    return getMaskCHTAddr(inputValue);
                case MaskType.name:
                    return getMaskName(inputValue);
                case MaskType.birth:
                    return getMaskBirthDay(inputValue);
                case MaskType.email:
                    return getMaskEmail(inputValue);
                default: return inputValue;
            }
        }
        #region Private Function
        /// <summary>
        /// 遮罩E-Mail地址
        /// </summary>
        /// <param name="EMAIL地址">partypeopleland@gmail.com</param>
        /// <returns>pxxxxxxxxxxxxxd@gmail.com</returns>
        private string getMaskEmail(string val)
        {
            string tmpID = val.Split('@')[0];
            string server = val.Split('@')[1];
            maskchar = null;

            int End = (tmpID.Length > 2) ? tmpID.Length - 2 : tmpID.Length - 1;
            maskstr = tmpID.Substring(1, End);
            maskchar = repeatString(_maskChar, maskstr.Length);
            rtn = tmpID.Replace(maskstr, maskchar) + "@" + server;
            this.Result = rtn;
            return rtn;
        }
        /// <summary>
        /// 遮罩生日年份
        /// </summary>
        /// <param name="生日">1980/10/15</param>
        /// <returns>xxxx/10/15</returns>
        private string getMaskBirthDay(string val)
        {
            maskstr = val.Substring(0, 4);
            maskchar = repeatString(_maskChar, maskstr.Length);
            rtn = val.Replace(maskstr, maskchar);
            this.Result = rtn;
            return rtn;
        }
        /// <summary>
        /// 遮罩名字(可接受英文名字)
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        private string getMaskName(string inputValue)
        {
            return (Regex.IsMatch(inputValue, RegularExp.Chinese)) ? getMaskCName(inputValue) : getMaskEName(inputValue);
        }
        /// <summary>
        /// 遮罩英文姓名
        /// </summary>
        /// <param name="英文姓名(姓氏 名字)">Lin Chin-San</param>
        /// <returns>Lin xxxx-San</returns>
        private string getMaskEName(string inputValue)
        {
            string rtn = inputValue;

            string[] aryName = inputValue.Split(' ');
            string lastName = aryName[1];
            if (lastName.IndexOf('-') > 1)
            {
                int tmpCnt = 0;
                string tmpName = string.Empty;
                foreach (var item in lastName.Split('-'))
                {
                    tmpCnt++;
                    tmpName += (tmpCnt != lastName.Split('-').Length) ? repeatString(_maskChar, item.Length) + "-" : item;
                }
                lastName = tmpName;
            }
            else
            {
                lastName = "xxxx";
            }

            rtn = aryName[0] + " " + lastName;
            this.Result = rtn;
            return rtn;
        }
        /// <summary>
        /// 遮罩中文姓名
        /// </summary>
        /// <param name="中文姓名">林青山</param>
        /// <returns>林x山</returns>
        private string getMaskCName(string val)
        {
            rtn = val;
            maskchar = null;
            int End = (int)(rtn.Length / 2);
            maskstr = rtn.Substring(1, End);
            maskchar = repeatString(_maskChar, maskstr.Length);
            rtn = rtn.Replace(maskstr, maskchar);
            this.Result = rtn;
            return rtn;
        }
        /// <summary>
        /// 遮罩中文地址(僅顯示前六字)
        /// </summary>
        /// <param name="inputValue">台北市信義區松高路8號</param>
        /// <returns>台北市信義區xxxxx</returns>
        private string getMaskCHTAddr(string inputValue)
        {
            rtn = string.Empty;
            rtn = inputValue.Substring(0, 6) + repeatString(_maskChar, inputValue.Length - 6);
            this.Result = rtn;
            return rtn;
        }
        /// <summary>
        /// 遮罩市內電話(不須帶入區碼及分機)
        /// </summary>
        /// <param name="市內電話號碼">87809966</param>
        /// <returns>87xxxx66</returns>
        private string getMaskTele(string inputValue)
        {
            maskstr = inputValue.Substring(2, 4);
            maskchar = repeatString(_maskChar, maskstr.Length);
            rtn = inputValue.Replace(maskstr, maskchar);
            this.Result = rtn;
            return rtn;
        }
        /// <summary>
        /// 遮罩大陸身分證字號，1-6位不隱藏、7-10隱藏、15、16、18隱藏
        /// </summary>
        /// <param name="inputValue">34052419800101001X</param>
        /// <returns>340524****0101**1*</returns>
        private string getMaskCnID(string inputValue)
        {
            rtn = string.Empty;
            string part1 = inputValue.Substring(0, 6);
            string part2 = repeatString(_maskChar, 4);
            string part3 = inputValue.Substring(10, 4);
            string part4 = repeatString(_maskChar, 2);
            string part5 = inputValue.Substring(16, 1);
            string part6 = repeatString(_maskChar, 1);
            rtn = part1 + part2 + part3 + part4 + part5 + part6;
            this.Result = rtn;
            return rtn;
        }
        /// <summary>
        /// 遮罩台灣身分證字號，顯示前二、後四碼
        /// </summary>
        /// <param name="台灣身份證字號">X123456787</param>
        /// <returns>X1xxxx6787</returns>
        private string getMaskTwID(string inputValue)
        {
            maskstr = inputValue.Substring(2, 4);
            maskchar = repeatString(_maskChar, maskstr.Length);
            rtn = inputValue.Replace(maskstr, maskchar);
            this.Result = rtn;
            return rtn;
        }
        /// <summary>
        /// 遮罩信用卡號碼(16數字)
        /// </summary>
        /// <param name="信用卡號碼">5555-2525-1266-2213</param>
        /// <returns>5555-25xx-xxxx-2213</returns>
        private string getMaskCreaditCard16(string inputValue)
        {
            string rtn = (Regex.IsMatch(inputValue.Replace("-", ""), RegularExp.creditcard) ? inputValue.Substring(0, 7) + repeatString(_maskChar, 2) + "-" + repeatString(_maskChar, 4) + inputValue.Substring(14, 5) : "");
            this.Result = rtn;
            return rtn;
        }
        /// <summary>
        /// 台灣手機號碼(10碼)，遮罩5到7碼
        /// </summary>
        /// <param name="手機號碼">0912345678</param>
        /// <returns>0912xxx678</returns>
        private string getMaskMobileNumberTW(string 手機號碼)
        {
            maskstr = 手機號碼.Substring(4, 3);
            maskchar = repeatString(_maskChar, maskstr.Length);
            rtn = 手機號碼.Replace(maskstr, maskchar);
            this.Result = rtn;
            return rtn;
        }
        /// <summary>
        /// 重複字串
        /// </summary>
        /// <param name="重複字元">x</param>
        /// <param name="重複次數">3</param>
        /// <returns>xxx</returns>
        private string repeatString(char 重複字元, int 重複次數)
        {
            var bu = new StringBuilder(重複次數);
            for (int i = 0; i < 重複次數; i++)
            {
                bu.Append(重複字元);
            }
            return bu.ToString();
        }
        #endregion
    }
}


