# MVCProjeKampi

[[mahmutogutcu.bsite.net](https://mahmutogutcu.bsite.net)](url)

## Proje İçeriği

Proje bir sözlük sitesidir. Anasayfada sizi bir vitrin karşılamaktadır. Bu sayede proje içeriğine ufaktan değinilmiş olur. Ardından Kayıt ol bölümünden yazar kayıdı oluşturup /Login/WriterLogin 'den (Giriş yap) giriş yapılabiliriz. 
Admin panelinden eklenen kategoriler sayesinde başlık oluşturabilir, bu başlığa da herkes tarafından içerik eklemesi yapılmasına olanak veririz. Bir nevi ekşi sözlük klonu gibidir.
Mail kutusu gibi mailleşmeler de sağlayabiliriz. Vitrin kısmından yollanan mesajları da adminler görebilmektedir.

3 kısımdan oluşan (admin-yazar-vitrin) proje içerisinde;
- .NET MVC5,
- MSSQL Veritabanı,
- Entity Framework CodeFirst,
- N-Katmanlı Mimari,
- Html5, Css, Bootstrap,
- JavaScript, JQuery 
teknolojilerine değinilmiştir.

Projeyi başlatabilmek için connectionString'i düzenledikten sonra, Package Manager Console'da **DataAccessLayer** seçilerek
```
enable-migration
```
yaptıktan sonra açılan pencerede
```
AutomaticMigrationsEnabled = true;
```
olarak değiştirilmesi gerekmektedir. Ardından 
```
update-database
```
yaparız. Artık veritabanımız hazır olacaktır.

Ardından projeyi başlatabiliriz.
