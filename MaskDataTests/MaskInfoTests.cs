using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaskData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MaskData.Tests {
    [TestClass()]
    public class MaskInfoTests {
        #region 測試Private 方法
        //[TestMethod()]
        //public void 遮罩台灣手機號碼() {
        //    //arrange
        //    MaskInfo target = new MaskInfo('x');
        //    string InputValue = "0912345678";
        //    string expected = "0912xxx678";
        //    string actual;
        //    //act
        //    PrivateObject param0 = new PrivateObject(target);
        //    param0.Invoke("getMaskMobileNumberTW", new object[] { InputValue });
        //    actual = target.Result;
        //    //assert
        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void 遮罩信用卡號碼() {
        //    //arrange
        //    MaskInfo target = new MaskInfo('x');
        //    string inVal = "5555-2525-1266-2213";
        //    string expected = "5555-25xx-xxxx-2213";
        //    string actual;
        //    //act
        //    PrivateObject param0 = new PrivateObject(target);
        //    param0.Invoke("getMaskCreaditCard16", new object[] { inVal });
        //    actual = target.Result;
        //    //assert
        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void 遮罩台灣身分證號碼()
        //{
        //    //arrange
        //    MaskInfo target = new MaskInfo('x');
        //    string inVal = "X123456787";
        //    string expected = "X1xxxx6787";
        //    string actual;
        //    //act
        //    PrivateObject param0 = new PrivateObject(target);
        //    param0.Invoke("getMaskTwID", new object[] { inVal });
        //    actual = target.Result;
        //    //assert
        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void 遮罩大陸身分證號碼()
        //{
        //    //arrange
        //    MaskInfo target = new MaskInfo('*');
        //    string inVal = "34052419800101001X";
        //    string expected = "340524****0101**1*";
        //    string actual;
        //    //act
        //    PrivateObject param0 = new PrivateObject(target);
        //    param0.Invoke("getMaskCnID", new object[] { inVal });
        //    actual = target.Result;
        //    //assert
        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void 遮罩市內電話()
        //{
        //    //arrange
        //    MaskInfo target = new MaskInfo('x');
        //    string inVal = "87809966";
        //    string expected = "87xxxx66";
        //    string actual;
        //    //act
        //    PrivateObject param0 = new PrivateObject(target);
        //    param0.Invoke("getMaskTele", new object[] { inVal });
        //    actual = target.Result;
        //    //assert
        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void 遮罩中文地址()
        //{
        //    //arrange
        //    MaskInfo target = new MaskInfo('x');
        //    string inVal = "台北市信義區松高路8號";
        //    string expected = "台北市信義區xxxxx";
        //    string actual;
        //    //act
        //    PrivateObject param0 = new PrivateObject(target);
        //    param0.Invoke("getMaskCHTAddr", new object[] { inVal });
        //    actual = target.Result;
        //    //assert
        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void 遮罩英文姓名()
        //{
        //    //arrange
        //    MaskInfo target = new MaskInfo('x');
        //    string inVal = "Lin Chin-San";
        //    string expected = "Lin xxxx-San";
        //    string actual;
        //    //act
        //    PrivateObject param0 = new PrivateObject(target);
        //    param0.Invoke("getMaskEName", new object[] { inVal });
        //    actual = target.Result;
        //    //assert
        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void 遮罩中文姓名()
        //{
        //    //arrange
        //    MaskInfo target = new MaskInfo('x');
        //    string inVal = "林青山";
        //    string expected = "林x山";
        //    string actual;
        //    //act
        //    PrivateObject param0 = new PrivateObject(target);
        //    param0.Invoke("getMaskCName", new object[] { inVal });
        //    actual = target.Result;
        //    //assert
        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void 遮罩姓名給中文()
        //{
        //    //arrange
        //    MaskInfo target = new MaskInfo('x');
        //    string inVal = "林青山";
        //    string expected = "林x山";
        //    string actual;
        //    //act
        //    PrivateObject param0 = new PrivateObject(target);
        //    param0.Invoke("getMaskName", new object[] { inVal });
        //    actual = target.Result;
        //    //assert
        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void 遮罩姓名給英文()
        //{
        //    //arrange
        //    MaskInfo target = new MaskInfo('x');
        //    string inVal = "Lin Chin-San";
        //    string expected = "Lin xxxx-San";
        //    string actual;
        //    //act
        //    PrivateObject param0 = new PrivateObject(target);
        //    param0.Invoke("getMaskName", new object[] { inVal });
        //    actual = target.Result;
        //    //assert
        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void 遮罩生日年份()
        //{
        //    //arrange
        //    MaskInfo target = new MaskInfo('x');
        //    string inVal = "1980/10/15";
        //    string expected = "xxxx/10/15";
        //    string actual;
        //    //act
        //    PrivateObject param0 = new PrivateObject(target);
        //    param0.Invoke("getMaskBirthDay", new object[] { inVal });
        //    actual = target.Result;
        //    //assert
        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void 遮罩Email地址()
        //{
        //    //arrange
        //    MaskInfo target = new MaskInfo('x');
        //    string inVal = "partypeopleland@gmail.com";
        //    string expected = "pxxxxxxxxxxxxxd@gmail.com";
        //    string actual;
        //    //act
        //    PrivateObject param0 = new PrivateObject(target);
        //    param0.Invoke("getMaskEmail", new object[] { inVal });
        //    actual = target.Result;
        //    //assert
        //    Assert.AreEqual(expected, actual);
        //}
        #endregion

        [TestMethod()]
        public void 遮罩台灣手機號碼()
        {
            //arrange
            MaskInfo target = new MaskInfo('x');
            string InputValue = "0912345678";
            string expected = "0912xxx678";
            string actual;
            //act
            target.getMaskValue(InputValue, MaskType.MobileNumberTW);
            actual = target.Result;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void 遮罩信用卡號碼()
        {
            //arrange
            MaskInfo target = new MaskInfo('x');
            string inVal = "5555-2525-1266-2213";
            string expected = "5555-25xx-xxxx-2213";
            string actual;
            //act
            target.getMaskValue(inVal, MaskType.CreaditCard16);
            actual = target.Result;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void 遮罩台灣身分證號碼()
        {
            //arrange
            MaskInfo target = new MaskInfo('x');
            string inVal = "X123456787";
            string expected = "X1xxxx6787";
            string actual;
            //act
            target.getMaskValue(inVal, MaskType.twID);
            actual = target.Result;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void 遮罩大陸身分證號碼()
        {
            //arrange
            MaskInfo target = new MaskInfo('*');
            string inVal = "34052419800101001X";
            string expected = "340524****0101**1*";
            string actual;
            //act
            target.getMaskValue(inVal, MaskType.cnID);
            actual = target.Result;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void 遮罩市內電話()
        {
            //arrange
            MaskInfo target = new MaskInfo('x');
            string inVal = "87809966";
            string expected = "87xxxx66";
            string actual;
            //act
            target.getMaskValue(inVal, MaskType.tele);
            actual = target.Result;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void 遮罩中文地址()
        {
            //arrange
            MaskInfo target = new MaskInfo('x');
            string inVal = "台北市信義區松高路8號";
            string expected = "台北市信義區xxxxx";
            string actual;
            //act
            target.getMaskValue(inVal, MaskType.CHTaddr);
            actual = target.Result;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void 遮罩英文姓名()
        {
            //arrange
            MaskInfo target = new MaskInfo('x');
            string inVal = "Lin Chin-San";
            string expected = "Lin xxxx-San";
            string actual;
            //act
            target.getMaskValue(inVal, MaskType.name);
            actual = target.Result;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void 遮罩中文姓名()
        {
            //arrange
            MaskInfo target = new MaskInfo('x');
            string inVal = "林青山";
            string expected = "林x山";
            string actual;
            //act
            target.getMaskValue(inVal, MaskType.name);
            actual = target.Result;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 遮罩生日年份()
        {
            //arrange
            MaskInfo target = new MaskInfo('x');
            string inVal = "1980/10/15";
            string expected = "xxxx/10/15";
            string actual;
            //act
            target.getMaskValue(inVal, MaskType.birth);
            actual = target.Result;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void 遮罩Email地址()
        {
            //arrange
            MaskInfo target = new MaskInfo('x');
            string inVal = "partypeopleland@gmail.com";
            string expected = "pxxxxxxxxxxxxxd@gmail.com";
            string actual;
            //act
            target.getMaskValue(inVal, MaskType.email);
            actual = target.Result;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
