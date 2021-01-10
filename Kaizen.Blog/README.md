# Kaizen Blog

## 1. Ne Kullandım?

#### ✓ C#

#### ✓ .Net Core Api

#### ✓ MSSQL

#### ✓ Swagger

#### ✓ JWT

#### ✓ EntityFramework Core

#### ✓ Code First

#### ✓ Repository Pattern

#### ✓ Unit Of Work Pattern

#### ✓ Dependency Injection

#### ✓ Postman

#### ✓ Bogus

#### ✓ Automapper

#### ✓ Serilog


## 2. Nasıl Kullandım?

- Dummy Data Ekleme

Dummy data eklemek için - Bogus -  isimli kütüphaneyi kullandım. Bu kütüphane sayesinde testlerim için gereken datayı oluşturmayı başardım. Bogus kütüphanesini kullanarak 1 tane kullanıcı (User), 3 tane Kategori(Category) ve 11306 tane makale(Article) oluşturdum. Bu sayı Seed sınıfı içerisine gidilerek daha da artırılabilir. 


- Verileri Kaydetme

EntityFramework yardımı ve Code first yaklaşımı ile MSSQL üzerinden veritabanımı oluşturdum.

Veritabanı oluştuktan sonra sıra dummy dataları program ilk açıldığında veritabanına kaydetme
işlemine geçtim. Bunun için Seed sınıfını oluşturdum ve program ilk açıldığında oluşturulan verilerin veritabanına atılması için Program.cs içerisinde gerekli düzenlemeri yaptım. Bu sayede program ilk çalıştırıldığında veritabanı oluşturulup dummy datalar içerisine atılabildi


- Repository, Unit Of Work


Veritabanına kayıt attıktan sonra sıra bu kayıtlar ve veritabanı üzerinden işlem yapmaya geldi.
Projenin daha da genişleyebileceğini göz önüne ve veritabanına yapılcak işlemleri tek bir sınıftan
yönetmek için alarak Generic Repository ve Unit Of Work sınıflarını oluşturdum. 

- Api Oluşturma

Dışarıdan veritabanında değişiklik yapabilmesi için .Net Core Api (5.0) kullandım. Bu apinin işlem
yapabilmesi için servislerin interfacelerini constructordan enjecte ettim. Service sınıflarıma da
GenericRepository interfacelerini enjecte ettim. Dependency injection yönetimini .Net Core da
default olarak bulunan container ile yönettim. Postman yardımı ile api controllerları test ettim. Apiye erişilmesi için swagger kullandım.

- Loglama

Basit anlamda lodgları .txt yazabilmek için serilog kütüphanesinden faydalandım. Burdaki amacım sadece logları yadırabilmek olduğundan dolayı çok fazla konfigürasyon yapmadım. Küçük bir konfigürasyon değişikliği ile serilog sayesinde logları Elasticsearche ya da veritabanına yönlendirebiliriz.


- Versiyon Yönetimi

Projeyi sizinde alıp inceleyebilmeniz için git altyapısını kullanan github sitesine yükledim. Projeye
https://github.com/ahmetunge/dotnet-core-angular-simple-phone-book linkinden ulaşabilirsiniz.

## 3. Uygulamayı Nasıl Çalıştırırsınız?

- Api çalıştıktan sonra veritabanı otomatik olarak proje içerisinde oluşup içerisine veriler yazılacaktır.
- Veritabanı data source bilgisi appsettings.json içerisinden okunmaktadır.
- **NOT: Bu yazdıklarımı bildiğinize eminim projeyi hızlı çalıştırabilmek için yukarıdakileri not düştüm. Lütfen**
    **beni yanlış anlamayın.**

## 4. Faydalandığım Kaynaklar ve Kişiler

- https://stackoverflow.com/
- https://www.nuget.org/
- https://www.udemy.com/
- https://github.com/
- https://github.com/bchavez/Bogus
- https://automapper.org/
- https://fluentvalidation.net/
- Neil Cummings
- Geçmişte yaptığım projeler (Ahmet Ünge)


## 5. Projeyi Nasıl Daha İyi Hale Getirebilirim.

- Categori ve projeye büyüyünce gerekli olacak bazı verileri Redis cache içerinde tutardım. 
- Hızlı bir arama için Elasticsearch kullanırdım.
- Veritabanına giren birinin şifreleri görmemesi için girilen şifreleri tek yönlü olarak salt(bir kelime) ile beraber şifreli bir şekilde veritabanına kaydederdim.
- Daha güzel bir loglama deneyimi için Elastic search kullanırdım.
- Uygulamayı dockerize ederdim.
- Unit testlerimi yazardım.
- Katmanlı bir mimari kurgulardım.



