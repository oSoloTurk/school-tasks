#include <malloc.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

struct Node {
  int value;
  struct Node* nextNode;
};

int workOne() {
  struct Node* list = malloc(sizeof(struct Node));
  struct Node* ptr = NULL;
  int input;
  char status = 'y';
  while (status == 'y') {
    printf("Say� girin : ");
    scanf("%d", &input);
    ptr = list;
    while (ptr->nextNode != NULL) {
      ptr = ptr->nextNode;
    }
    ptr->value = input;
    ptr->nextNode = malloc(sizeof(struct Node));
    ptr->nextNode->nextNode = NULL;
    printf("\ny/n : ");
    scanf("%s", &status);
  }
  ptr = list;
  while (ptr->nextNode != NULL) {
    printf("\nDe�er: %d, Adress: %x, Sonraki Adress: %x", ptr->value,
           (unsigned int)ptr, (unsigned int)ptr->nextNode);
    ptr = ptr->nextNode;
  }
  return 0;
}

int workTwo() {
  int type;
  printf("Manuel girdilerle �al��mak i�in 1 yaz�n\n");
  printf("Rastgele girdilerle �al��mak i�in 2 yaz�n\n");
  printf("Say� girin :");
  scanf("%d", &type);

  struct Node* list = malloc(sizeof(struct Node));
  struct Node* ptr = NULL;
  char status = 'y';
  int input, result;

  if (type == 1) {
    while (status == 'y') {
      printf("\nSay� Girin: ");
      scanf("%d", &input);

      // add element
      ptr = list;
      while (ptr->nextNode != NULL) {
        ptr = ptr->nextNode;
      }
      ptr->value = input;
      ptr->nextNode = malloc(sizeof(struct Node));
      ptr->nextNode->nextNode = NULL;

      //

      printf("\ny/n : ");
      scanf("%s", &status);
    }
  } else {
    if (type != 2)
      printf(
          "Tan�mlanmam�� t�r girdi�iniz i�in rastgele modunda �al��t�r�l�yor.");
    srand(time(NULL));
    printf("\nGirdiler: ");
    for (int times = 0; times < 50; times++) {
      input = rand() % 1000;
      printf("%d ", input);

      // add element
      ptr = list;
      while (ptr->nextNode != NULL) {
        ptr = ptr->nextNode;
      }
      ptr->value = input;
      ptr->nextNode = malloc(sizeof(struct Node));
      ptr->nextNode->nextNode = NULL;

      //
    }
  }
  status = 'y';
  while (status == 'y') {
    printf("\nAranacak De�er: ");
    scanf("%d", &input);

    // search element
    ptr = list;
    struct Node* onceki = NULL;
    int find = 0;
    while (ptr->nextNode != NULL) {
      if (ptr->value == input) {
        printf("\n+ | %d elemean� listede bulunuyor.", input);
        find = 1;
        // remove element
        if (onceki == NULL)
          list = ptr->nextNode;
        else {
          free(onceki->nextNode);
          onceki->nextNode = ptr->nextNode;
        }
        break;
      }
      onceki = ptr;
      ptr = ptr->nextNode;
    }
    if (!find) printf("\n- | %d eleman� listede bulunmuyor.", input);
    //
    printf("\ny/n : ");
    scanf("%s", &status);
  }
  return 0;
}

struct OGRENCI {
  int id;
  float vize;
  float finalNotu;
  float ortalama;
  struct OGRENCI* sonraki;
};

int workThree() {
  char status = 'y';
  float input;
  struct OGRENCI* list = malloc(sizeof(struct Node));
  struct OGRENCI* ptr = NULL;
  int id = 0;
  while (status == 'y') {
    // add element
    ptr = list;
    while (ptr->sonraki != NULL) {
      ptr = ptr->sonraki;
    }
    ptr->sonraki = malloc(sizeof(struct Node));
    ptr->sonraki->sonraki = NULL;

    //

    // fill element
    printf("\n%d. ogrenci i�in vize notu giriniz: ", id);
    scanf("%f", &input);
    ptr->vize = input;

    printf("\n%d. ogrenci i�in final notu giriniz: ", id);
    scanf("%f", &input);
    ptr->finalNotu = input;

    ptr->id = id++;
    //

    printf("\ny/n : ");
    scanf("%s", &status);
  }
  ptr = list;
  while (ptr->sonraki != NULL) {
    ptr->ortalama = ((ptr->vize * 4) + (ptr->finalNotu * 6)) / 10;
    printf("\n%d. ogrencinin ortalama notu : %.1f (%.1f,%.1f)", ptr->id,
           ptr->ortalama, ptr->vize, ptr->finalNotu);
    ptr = ptr->sonraki;
  }
  return 0;
}

int main(void) { return workThree(); }