using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Web;

namespace Shopping.Common
{
    #region Upload
    public class Upload
    {
        private int _allowMaxSize = 0x1f4000;
        private string _contentType;
        private int _err = 0;
        private string _fileExt = string.Empty;
        private string _fileName = string.Empty;
        private int _fileSize = 0;
        private string _inceptFile = "jpg,jpeg,gif,bmp,png,swf,mid,wav,mp3,rmi,txt,cda,avi,mpg,mpeg,wov,asf,ra,rm,ram,rmvb,rar,zip";
        private string _originFileName = string.Empty;
        private string _transparence = "0.1";

        public bool CheckFileExt(string fileExt)
        {
            if (!string.IsNullOrEmpty(fileExt))
            {
                fileExt = fileExt.ToLower();
                string[] strArray = this._inceptFile.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].ToString().ToLower() == fileExt)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int CheckFileType(string fileExt)
        {
            if ("gif,jpg,jpeg,png,bmp,txt".IndexOf(fileExt.ToLower()) >= 0)
            {
                return 1;
            }
            if ("swf".IndexOf(fileExt.ToLower()) >= 0)
            {
                return 2;
            }
            if ("mid,wav,mp3,rmi,cda".IndexOf(fileExt.ToLower()) >= 0)
            {
                return 3;
            }
            if ("avi,mpg,mpeg,wov,asf".IndexOf(fileExt.ToLower()) >= 0)
            {
                return 4;
            }
            if ("ra,ram,rm,rmvb".IndexOf(fileExt.ToLower()) >= 0)
            {
                return 5;
            }
            if ("rar,zip".IndexOf(fileExt.ToLower()) >= 0)
            {
                return 6;
            }
            return 0;
        }

        public string ErrString()
        {
            switch (this._err)
            {
                case 1:
                    return "文件地址不能为空!";

                case 2:
                    return "文件类型不正确!";

                case 3:
                    return ("文件大小超过" + this._allowMaxSize + "KB!");

                case 4:
                    return "无效的图形格式!";

                case 5:
                    return "上传文件错误!";
            }
            return "";
        }

        public string GetRandFileName(int randNum)
        {
            DateTime now = new DateTime();
            Random random = new Random(randNum);
            now = DateTime.Now;
            return (now.ToString("yyyyMMddHHmmss") + now.Millisecond.ToString() + random.Next(0x2710, 0x1869f).ToString());
        }

        public void Save(HttpPostedFile file, string uploadPath, out string saveFilenme)
        {
            saveFilenme = "";
            try
            {
                this._fileName = file.FileName;
                if (this._fileName == "")
                {
                    this._err = 1;
                }
                else
                {
                    this._fileExt = Path.GetExtension(this._fileName).Remove(0, 1);
                    this._fileSize = file.ContentLength;
                    if (!this.CheckFileExt(this._fileExt))
                    {
                        this._err = 2;
                    }
                    //else if (file.ContentType.ToString().IndexOf("image") < 0)
                    //{
                  
                    //}
                    else if (this._fileSize < 1)
                    {
                        this._err = 1;
                    }
                    else if (this._fileSize > (this._allowMaxSize * 0x400))
                    {
                        this._err = 3;
                    }
                    else
                    {
                        this._originFileName = this._fileName.Replace(@"\", "/");
                        this._originFileName = this._originFileName.Substring(this._originFileName.LastIndexOf('/') + 1);
                        Utils.CreateFolder(uploadPath);
                        this._contentType = file.ContentType;
                        this._fileName = this.GetRandFileName(this._fileSize) + "." + this._fileExt;
                        saveFilenme = uploadPath + this._fileName;
                        file.SaveAs(Utils.GetMapPath(uploadPath) + this._fileName);
                        file = null;
                    }
                }
            }
            catch
            {
                this._err = 5;
            }
        }
        public void Save1(string fileName, string uploadPath, out string saveFilenme)
        {
            saveFilenme = "";
        }
        public void Save(HtmlInputFile file, string uploadPath)
        {
            try
            {
                this._fileName = file.PostedFile.FileName;
                if (this._fileName == "")
                {
                    this._err = 1;
                }
                else
                {
                    this._fileExt = Path.GetExtension(this._fileName).Remove(0, 1);
                    this._fileSize = file.PostedFile.ContentLength;
                    if (!this.CheckFileExt(this._fileExt))
                    {
                        this._err = 2;
                    }
                    else if ((this.CheckFileType(this._fileExt) == 1) && (file.PostedFile.ContentType.ToString().IndexOf("image") < 0))
                    {
                        this._err = 4;
                    }
                    else if (this._fileSize < 1)
                    {
                        this._err = 1;
                    }
                    else if (this._fileSize > (this._allowMaxSize * 0x400))
                    {
                        this._err = 3;
                    }
                    else
                    {
                        this._originFileName = this._fileName.Replace(@"\", "/");
                        this._originFileName = this._originFileName.Substring(this._originFileName.LastIndexOf('/') + 1);
                        Utils.CreateFolder(uploadPath);
                        this._contentType = file.PostedFile.ContentType;
                        this._fileName = this.GetRandFileName(this._fileSize) + "." + this._fileExt;
                        file.PostedFile.SaveAs(Utils.GetMapPath(uploadPath) + this._fileName);
                        file.Dispose();
                    }
                }
            }
            catch
            {
                this._err = 5;
            }
        }

        public int AllowMaxSize
        {
            get
            {
                return this._allowMaxSize;
            }
            set
            {
                if ((value > 0) && (value < this._allowMaxSize))
                {
                    this._allowMaxSize = value;
                }
            }
        }

        public string ContentType
        {
            get
            {
                return this._contentType;
            }
        }

        public int Err
        {
            get
            {
                return this._err;
            }
            set
            {
                this._err = value;
            }
        }

        public string FileExt
        {
            get
            {
                return this._fileExt;
            }
        }

        public string FileName
        {
            get
            {
                return this._fileName;
            }
        }

        public int FileSize
        {
            get
            {
                return this._fileSize;
            }
        }

        public string InceptFile
        {
            get
            {
                return this._inceptFile;
            }
            set
            {
                this._inceptFile = value;
            }
        }

        public string OriginFileName
        {
            get
            {
                return this._originFileName;
            }
        }

        public string Transparence
        {
            get
            {
                return this._transparence;
            }
            set
            {
                this._transparence = value;
            }
        }
    }

    #endregion
}
