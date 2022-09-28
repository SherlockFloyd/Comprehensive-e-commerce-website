using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Shopping.Model
{
	///<summary>
    ///	定时更新记录表
    ///	Model实体层 Shopping_TimerServiceLog
    ///</summary>
	public class TimerServiceLog
	{     
	
		#region  TableProperty
      	        /// <summary>
		/// ID
        /// </summary>		
		private int _logid;
        public int LogID
        {
            get{ return _logid; }
            set{ _logid = value; }
        }        
		        /// <summary>
		/// 更新的项目
        /// </summary>		
		private string _logname;
        public string LogName
        {
            get{ return _logname; }
            set{ _logname = value; }
        }        
		        /// <summary>
		/// 起始时间
        /// </summary>		
		private DateTime _starttime;
        public DateTime StartTime
        {
            get{ return _starttime; }
            set{ _starttime = value; }
        }        
		        /// <summary>
		/// 结束时间
        /// </summary>		
		private DateTime _endtime;
        public DateTime EndTime
        {
            get{ return _endtime; }
            set{ _endtime = value; }
        }        
		   		#endregion 
   		
   		#region TablePropertyEx
   		
   		#endregion
	}
}