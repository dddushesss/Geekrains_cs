using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace lesson_8_4
{
    class TrueFalse
    {
        string fileName;
        List<Question> list;
        public string FileName
        {
            set { fileName = value; }
        }
        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }
        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }
        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }
        // Индексатор - свойство для доступа к закрытому объекту
        public Question this[int index]
        {
            get
            {
                var res = list[index];
                list.Remove(list[index]);
                return res;
            }

        }
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }
        public bool Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            XmlReader reader = new XmlTextReader(fStream);
            try
            {
                if (xmlFormat.CanDeserialize(reader))
                {
                    list = (List<Question>)xmlFormat.Deserialize(reader);
                    fStream.Close();
                }
                else
                {
                    fStream.Close();
                    return false;
                }
                return true;
            }
            catch
            {
                fStream.Close();
                return false;
            };
        }
        public int Count
        {
            get { return list.Count; }
        }
    }

}
