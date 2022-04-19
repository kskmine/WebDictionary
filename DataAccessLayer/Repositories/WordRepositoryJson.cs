using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class WordRepositoryJson : IRepositoryWord
    {
        static List<Word> _word = new List<Word>();
        public void AddOrUpdate(Word word)
        {

            if (!_word.Any())
            {
                word.Id = 1;

            }
            else
            {
                word.Id = _word.Max(c => c.Id) + 1;

            }
            _word.Add(word);
            SaveChanges();
        }

        public void Delete(Word word)
        {
            _word.Remove(word);
            SaveChanges();
        }

        public void Delete(int id)
        {
            Word silinecek = _word.FirstOrDefault(c => c.Id == id);
            //First : kayıt yoksa hata alır
            //FirstOrDefault :kayıt yoksa null döner
            //Single: kayıt 1 adet değilse hata alır

            if (silinecek != null)
            {
                Delete(silinecek);
            }
        }

        public List<Word> List()
        {
            string fileContent = File.ReadAllText(@"C:\Users\SC-205 1\source\repos\Tu\WebDictionary\WebDictionary\bin\Debug\net5.0\Kelimeler.json");
            _word = JsonSerializer.Deserialize<List<Word>>(fileContent);
            return _word.ToList();
        }

        public void SaveChanges()
        {
            string serializedKelimeler = JsonSerializer.Serialize(_word);
            File.WriteAllText(@"C:\Users\SC-205 1\source\repos\Tu\WebDictionary\WebDictionary\bin\Debug\net5.0\Kelimeler.json", serializedKelimeler);

        }
    }
}
