#include <stdio.h>

struct il {
  int plaka;
  char ad[14];  // En uzun ada sahip ilimiz 14 harf ile Afyonkarahisar'dýr.
};

int getInput(int *plaka, char *mesaj) {
  printf("%s", mesaj);
  if ((scanf("%d", plaka)) != 1) {
    return 0;
  }
  return 1;
}

void write() {
  int index = 0;
  FILE *file;
  if ((file = fopen("sehirler.dat", "wb")) == NULL) {
    printf("Bulundugunuz dizinde yazma izniniz yok.");
    return;
  }
  struct il aktifEleman;
  while (index < 10) {
    if (!(getInput(&aktifEleman.plaka,
                   "\nEklenecek ilin plaka kodunu girin:") == 1 &&
          aktifEleman.plaka > 0 && aktifEleman.plaka <= 81)) {
      printf(
          "\nGeçerli bir plaka girmediniz. (Plakalar 1 den 81 e kadar "
          "sayilardir.)");
      continue;
    }
    printf("\n%d plakalý þehrin adýný girin:", aktifEleman.plaka);
    scanf("%s", aktifEleman.ad);
    fseek(file, (aktifEleman.plaka - 1) * sizeof(aktifEleman), SEEK_SET);
    fwrite(&aktifEleman, sizeof(aktifEleman), 1, file);
    index++;
  }
  printf("Islem tamamlandi.");
  fclose(file);
}

void read() {
  FILE *file;
  if ((file = fopen("sehirler.dat", "rb")) == NULL) {
    printf("Bulundugunuz dizinde yazma izniniz yok.");
    return;
  }
  int plaka;
  printf("");
  while (getInput(&plaka, "\nYeni sorgulama icin plaka kodu giriniz: ") == 1 &&
         plaka > 0 && plaka <= 81) {
    struct il aktifEleman;
    fseek(file, (plaka - 1) * sizeof(aktifEleman), SEEK_SET);
    if (fread(&aktifEleman, sizeof(aktifEleman), 1, file) != 1 ||
        aktifEleman.plaka == 0) {
      printf("\nAradiginiz ile dair plaka verisi mevcut deðil.");
      continue;
    }
    printf("\n%d plakali ilimizin adi %s", aktifEleman.plaka, aktifEleman.ad);
  }
  printf("Islem tamamlandi.");
}

int main(void) {
  write();
  read();
  return 0;
}