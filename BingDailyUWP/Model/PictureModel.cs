using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingDailyUWP.Model
{
    public class PictureModel : INotifyPropertyChanged
    {
        public PictureModel()
        {

        }

        /// <summary>
        /// Picture ID
        /// </summary>
        private string _pictureId;

        public string PictureId
        {
            get { return _pictureId; }
            set
            {
                _pictureId = value;
                NotifyPropertyChanged("PictureId");
            }
        }

        /// <summary>
        /// Picture Title
        /// </summary>
        private string _pictureTitle;

        public string PictureTitle
        {
            get { return _pictureTitle; }
            set
            {
                _pictureTitle = value;
                NotifyPropertyChanged("PictureTitle");
            }
        }

        /// <summary>
        /// Picture attribute
        /// </summary>
        private string _pictureAttr;

        public string PictureAttr
        {
            get { return _pictureAttr; }
            set
            {
                _pictureAttr = value;
                NotifyPropertyChanged("PictureAttr");
            }
        }

        /// <summary>
        /// Picture Description
        /// </summary>
        private string _pictureDescription;

        public string PictureDescription
        {
            get { return _pictureDescription; }
            set
            {
                _pictureDescription = value;
                NotifyPropertyChanged("PictureDescription");
            }
        }

        /// <summary>
        /// Picture Startdate
        /// </summary>
        private string _pictureStartdate;

        public string PictureStartdate
        {
            get { return _pictureStartdate; }
            set
            {
                _pictureStartdate = value;
                NotifyPropertyChanged("PictureStartdate");
            }
        }

        /// <summary>
        /// Picture Enddate
        /// </summary>
        private string _pictureEnddate;

        public string PictureEnddate
        {
            get { return _pictureEnddate; }
            set
            {
                _pictureEnddate = value;
                NotifyPropertyChanged("PictureEnddate");
            }
        }

        /// <summary>
        /// Picture Fullstartdate
        /// </summary>
        private string _pictureFullstartdate;

        public string PictureFullstartdate
        {
            get { return _pictureFullstartdate; }
            set
            {
                _pictureFullstartdate = value;
                NotifyPropertyChanged("PictureFullstartdate");
            }
        }

        /// <summary>
        /// Picture Url
        /// </summary>
        private string _pictureUrl;

        public string PictureUrl
        {
            get { return _pictureUrl; }
            set
            {
                _pictureUrl = value;
                NotifyPropertyChanged("PictureUrl");
            }
        }

        /// <summary>
        /// Picture UrlBase
        /// </summary>
        private string _pictureUrlbase;

        public string PictureUrlbase
        {
            get { return _pictureUrlbase; }
            set
            {
                _pictureUrlbase = value;
                NotifyPropertyChanged("PictureUrlbase");
            }
        }

        /// <summary>
        /// Picture Copyright
        /// </summary>
        private string _pictureCopyright;

        public string PictureCopyright
        {
            get { return _pictureCopyright; }
            set
            {
                _pictureCopyright = value;
                NotifyPropertyChanged("PictureCopyright");
            }
        }

        /// <summary>
        /// Picture CopyrightLink
        /// </summary>
        private string _pictureCopyrightlink;

        public string PictureCopyrightlink
        {
            get { return _pictureCopyrightlink; }
            set
            {
                _pictureCopyrightlink = value;
                NotifyPropertyChanged("PictureCopyrightlink");
            }
        }

        /// <summary>
        /// Picture Hsh
        /// </summary>
        private string _pictureHsh;

        public string PictureHsh
        {
            get { return _pictureHsh; }
            set
            {
                _pictureHsh = value;
                NotifyPropertyChanged("PictureHsh");
            }
        }

        /// <summary>
        /// Picture Qiniu_url
        /// </summary>
        private string _pictureQiniuUrl;

        public string PictureQiniuUrl
        {
            get { return _pictureQiniuUrl; }
            set
            {
                _pictureQiniuUrl = value;
                NotifyPropertyChanged("PictureQiniuUrl");
            }
        }

        /// <summary>
        /// Picture Date
        /// </summary>
        private string _pictureDate;

        public string PictureDate
        {
            get { return _pictureDate; }
            set
            {
                _pictureDate = value;
                NotifyPropertyChanged("PictureDate");
            }
        }

        /// <summary>
        /// PropertyChangedEventHandler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
