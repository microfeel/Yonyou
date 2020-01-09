using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class PersonResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("person")]
        public Person Person { get; set; }        
    }

    public class PersonListResult : DbListResult<Person>
    {
        [JsonPropertyName("person")]
        public override List<Person> List { get; set; }
    }

}
