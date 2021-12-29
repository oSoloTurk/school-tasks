#include <malloc.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int kThBitIsOne(int number, int k) {
  if (number & (1 << k))
    return 1;
  else
    return 0;
}

int firstWork() {
  FILE* file;
  if ((file = fopen("sayi.txt", "w")) == NULL) {
    printf("We do not acces to file for write operation\n");
    return 0;
  }
  srand(time(NULL));
  for (int index = 0; index < 100; index++) {
    fprintf(file, "%d\n", rand() % 100);
  }
  fclose(file);
  printf("Random numbers created\n");
  if ((file = fopen("sayi.txt", "r")) == NULL) {
    printf("We do not acces to file for read operation\n");
    return 0;
  }

  int counter = 0;
  int* numbers = malloc(sizeof(int));
  int number = 0;
  while (fscanf(file, "%d", &number) != EOF) {
    if (!kThBitIsOne(number, 5)) {
      numbers = realloc(numbers, (counter + 1) * sizeof(int));
      *(numbers + counter++) = number;
    }
  }
  printf("Numbers moved to array\n");
  fclose(file);
  for (int index = 0; index < counter; index++) {
    printf("%d\n", *(numbers + index));
  }
  return 0;
}

int secondWork() {
  int number = 0;
  int* numbers = malloc(sizeof(int));
  int counter = 0;
  do {
    printf("Enter a number (negative for exit): ");
    scanf("%d", &number);
    if (number % 15 == 0) {
      numbers = realloc(numbers, (counter + 1) * sizeof(int));
      *(numbers + counter++) = number;
    }
  } while (number >= 0);
  printf("Numbers moved to array\n");
  for (int index = 0; index < counter; index++) {
    printf("%d\n", *(numbers + index));
  }
}

int main(void) { firstWork(); }