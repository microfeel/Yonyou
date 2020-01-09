import requests
from lxml import etree

plist=[]
#关联的内类集合
subclassList = []

class Property(object):
    def __init__(self,n,t,c):
        self.name=n
        self.typename=t
        self.comment=c

class Subclass(object):

    def __init__(self,name):
        self.name=name
        self.properties =[]

    def AddProperty(self,name,typename,comment):
        self.properties.append(Property(name,typename,comment))

    def GenCode(self,tab):
        code = tab+'public class '+self.name +tab+'{'

        for p in self.properties:
            code += tab+'\t'+AddProperty(p.name,p.typename,p.comment,'\r\t\t\t')
        code += '\r'+tab+'}'
        return code


def GetSubclass(name):
    for sc in subclassList:
        if sc.name==name:
            return sc
    sc =Subclass(name)
    subclassList.append(sc)
    return sc

def AddCSHeader(classname):
    used = "using System;"
    used += "\rusing System.Collections.Generic;"
    used += "\rusing System.Text.Json.Serialization;"
    used += '\r\r' + "namespace MicroFeel.Yonyou.Api"
    used += '\r' + "{"
    used += '\r\t' + "public class " + classname + "\r\t{"
    return used

def AddProperty(name,type,comment,tab ='\r\t\t'):
    if plist.__contains__(name):
        return ''
    else:
        plist.append(name) 

    if comment== None:
        comment = ''
    comm = tab +"///<Summary>"
    comm += tab+"///" + comment
    comm += tab+"///</Summary>"
    # attr = tab+'[JsonPropertyName("' + name + '")]'  
    if type == None:
        type='string'
    if type=='number':
        type = 'float'
    if type=='date':
        type = 'DateTime'

    p = tab+"public " + type + " " + name.replace('_',' ').title().replace(' ','') + " { get;set; }"
    return comm + p

def AddTail():
    content = "\t}\r}"
    return content 


html = requests.get("http://open.yonyouup.com/apiCenter/index")

etree_html = etree.HTML(html.text)

apiurls = etree_html.xpath('//*[@id="allapi"]/div/table/tbody/tr/td/a/@href')

for url in apiurls:
    if not url.endswith("_add"): continue 
    #fullurl = "http://open.yonyouup.com/apiCenter/" + url
    url ="saleout_get";
    fullurl="http://open.yonyouup.com/apiCenter/"+ url;
    classname = url.replace('/','').replace('_get','').title()
    filecontent = AddCSHeader(classname)
    html = requests.get(fullurl)
    body = etree.HTML(html.text)
    trelements = body.xpath('.//*[@id="bodyContent"]/table[4]/tr')
    
    plist.clear()
    subclassList.clear()

    for tr in trelements:
        tds = tr.xpath('.//td')
        #表头,直接跳过
        if len(tds) == 0:
            continue
        if tds[0].text == None:
            namestr = tds[0].xpath('./a/text()')[0]
        else:
            namestr = tds[0].text

        typestr = tds[1].text
        last= len(tds)-1
        #生成内类
        if len(tds) >= 4 and tds[2]!= None and tds[2].text != None and tds[2].text != '\xa0':
            namestr = url.replace('/','').replace('_get','').title()+tds[2].text.title()
            typestr = 'IList<'+namestr+'>'
            sc=GetSubclass(namestr)
            sc.AddProperty(tds[0].text, tds[1].text,tds[last].text);

        filecontent = filecontent + AddProperty(namestr,typestr,tds[last].text)

    #添加内类
    filecontent += '\r'
    for sc in subclassList:
        filecontent +=  sc.GenCode('\r\t\t')
    #添加尾
    filecontent = filecontent + '\r' + AddTail()    
    print(filecontent)

    #保存到文件
    csfile = open('d:\\results\\model\\'+classname+'.cs', 'wt',encoding="utf-8")
    csfile.write(filecontent)
    csfile.close()



