Bu proje Clean Code ve katmanlı mimari teknikleri uygulanarak geliştirilmiş bir blog projesidir. Proje genel kullanıcı, kayıtlı kullanıcı ve admin panellerini içermektedir.

KATMANLAR;
Core Katmanı, projenin genel tanımlanan operasyonlarını içermektedir. Kod tekrarının önüne geçmek amacıyla diğer katmanlar temel operasyonlara bu katmandan ulaşmaktadır.
Entity Katmanı, veri tabanında oluşacak tablolar ve tablolara ait bilgiler bu katmanda tutulmaktadır.
Data Access Katmanı, veri tabanını code first ile oluşturmak için gereken kodlar bu katmanda bulunmaktadır.
Business Katmanı, iş kurallarının bulunduğu katmandır.
WebApp Katmanı ise projenin son kullanıcıya yönelik kodları içeren katmandır.


# SampleProject
