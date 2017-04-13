using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using TylerEfLibrary;
using TylerEfLibrary.Model;

namespace TylerRestAPI
{
    public class JsonUtils
    {

        //Serialize to JSON
        public String serialize(Object o) {
          return  JsonConvert.SerializeObject(o,Formatting.Indented,new JsonSerializerSettings(){
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        public Object deserialize(String json, ModelType type) {
            switch (type) {
                case ModelType.CATEGORY:
                    {
                        return JsonConvert.DeserializeObject<tblCategoryType>(json, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                    }
                case ModelType.CONFLUENCE_LINK:
                    {
                        return JsonConvert.DeserializeObject<tblConfluenceLink>(json, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                    }
                case ModelType.EMAIL_REMINDER:
                    {
                        return JsonConvert.DeserializeObject<tblEmailReminder>(json, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                    }
                case ModelType.REPORT:
                    {
                        return JsonConvert.DeserializeObject<tblReport>(json, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

                    }
                 
                case ModelType.REPORT_TYPE:
                    {
                        return JsonConvert.DeserializeObject<tblReportType>(json, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

                    }
             
                case ModelType.REVIEW:
                    {
                        return JsonConvert.DeserializeObject<tblReview>(json, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

                    }
                  
                case ModelType.STATE:
                    {
                        return JsonConvert.DeserializeObject<tblState>(json, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

                    }
               
            }
            return null;
           
        }

    }
}