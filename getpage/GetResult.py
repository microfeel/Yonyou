import os

def AddCSHeader(classname):
    used = "using System;"
    used += "\rusing System.Collections.Generic;"
    used+="\rusing MicroFeel.Yonyou.Api.Model.Result;"
    used += "\rusing System.Text.Json.Serialization;"
    used += '\r\r' + "namespace MicroFeel.Yonyou.Api"
    used += '\r' + "{"
    used += '\r\t' + "public class " + classname + "Result:"+classname+",IApiResult\r\t{"
    return used

def AddListCSHeader(classname): 
    used = '\r\t' + "public class " + classname + "ListResult: DbListResult<"+classname+">\r\t{"
    return used


def AddTail():
    content = "\t}\r"
    return content 

path = "D:\git\Yonyou\MicroFeel.Yonyou.Api\Model\Data\Purchasere" #文件夹目录
files= os.listdir(path) #得到文件夹下的所有文件名称
for file in files: #遍历文件夹
    print(file)
    classname = file.replace(".cs","") 
    filecontent = AddCSHeader(classname);
    filecontent +='''[JsonPropertyName("errcode")]\r
                     public string Errcode { get; set; }\r
                     [JsonPropertyName("errmsg")]\r
                     public string Errmsg { get; set; }\r''';
    filecontent +=AddTail()
    filecontent +=AddListCSHeader(classname) 
    filecontent +="[JsonPropertyName(\""+classname.lower()+"list\")]\r"
    filecontent +="public override List<"+classname+"> List { get; set; }"
    filecontent += AddTail()
    filecontent += AddTail()
    csfile = open("D:\git\Yonyou\MicroFeel.Yonyou.Api\Model\Result\Purchasere\\"+classname+"Result.cs", 'wt',encoding="utf-8")
    csfile.write(filecontent)
    csfile.close()


