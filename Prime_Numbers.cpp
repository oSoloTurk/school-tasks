#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int isPrime(int number) {
  for (int i = 2; i < number; i++)
    if (number % i == 0) return 0;
  return 1;
}

void fillRandomNumbers() {
  FILE *file;
  if ((file = fopen("sayilar.txt", "w")) != NULL) {
    srand(time(NULL));
    for (int i = 0; i < 100; i++) {
      fprintf(file, "%d\n", rand() % 1000);
    }
    fclose(file);
  } else
    printf("Ilgili klasöre yazma izniniz yok!");
}

void detectPrimes() {
  FILE *file;
  FILE *secondFile;
  if ((file = fopen("sayilar.txt", "r")) != NULL &&
      (secondFile = fopen("sayilar2.txt", "w")) != NULL) {
    int sayi;
    while (fscanf(file, "%d", &sayi) != EOF) {
      if (isPrime(sayi)) fprintf(secondFile, "%d\n", sayi);
    }
  } else
    printf("Ilgili klasöre yazma izniniz yok!");
}

int main(void) {
  fillRandomNumbers();
  detectPrimes();
  return 0;
}