#include <malloc.h>
#include <stdio.h>
#include <stdlib.h>

struct Node {
  int value;
  struct Node* next;
};

// initalize
struct Node* stackNode = NULL;
struct Node* queueNode = NULL;

// stack start

// stack show (4-3)
void showViewStack(int* foundNumber) {
  printf("\nStack Ciktisi (Top): ");
  struct Node* temp = stackNode;
  while (temp != NULL) {
    if (foundNumber != NULL && temp->value == *foundNumber)
      printf(" - (%d) ", temp->value);
    else
      printf(" - %d ", temp->value);
    temp = temp->next;
  }
  printf("-");
}

// stack add (1)
void addStack(int* input) {
  struct Node* newNode = malloc(sizeof(struct Node));
  newNode->value = *input;
  if (stackNode == NULL)
    newNode->next = NULL;
  else
    newNode->next = stackNode;
  stackNode = newNode;
}

// stack find and remove (2)
void findAndRemoveStack(int* find) {
  struct Node* startTemp = stackNode;
  struct Node* cutTemp = NULL;
  int found = 0;
  while (stackNode != NULL) {
    if (stackNode->value == *find) {
      found = 1;
      break;
    }
    cutTemp = stackNode;
    stackNode = stackNode->next;
  }
  if (found) {
    cutTemp->next = stackNode->next;
    free(stackNode);
    printf("\n[STACK] Eleman listede bulundu ve silindi..");
  } else
    printf("\n[STACK] Listede eleman bulunamadi.");
  stackNode = startTemp;
}

// stack find and show (3)
void findAndShowStack(int* find) {
  struct Node* startTemp = stackNode;
  int found = 0;
  while (stackNode != NULL) {
    if (stackNode->value == *find) {
      found = 1;
      break;
    }
    stackNode = stackNode->next;
  }
  if (found) {
    showViewStack(find);
    printf("\n[STACK] Eleman listede bulundu.");
  } else
    printf("\n[STACK] Listede eleman bulunamadi.");
  stackNode = startTemp;
}

// stack end

// queue start

// queue show (4-3)
void showViewQueue(int* foundNumber) {
  printf("\nQueue Ciktisi (Front): ");
  struct Node* writed = NULL;
  do {
    struct Node* temp = queueNode;
    while (temp->next != writed) temp = temp->next;
    if (foundNumber != NULL && temp->value == *foundNumber)
      printf(" - (%d) ", temp->value);
    else
      printf(" - %d ", temp->value);
    if (queueNode == temp) break;
    writed = temp;
  } while (writed != NULL);
  printf("-");
}

// queue add (1)
void addQueue(int* value) {
  struct Node* newBack = (struct Node*)malloc(sizeof(struct Node));
  newBack->value = *value;
  if (queueNode == NULL) {
    newBack->next = NULL;
    queueNode = newBack;
  } else {
    newBack->next = queueNode;
    queueNode = newBack;
  }
}

// queue find and remove (2)
void findAndRemoveQueue(int* find) {
  struct Node* startTemp = queueNode;
  struct Node* cutTemp = NULL;
  int found = 0;
  while (queueNode != NULL) {
    if (queueNode->value == *find) {
      found = 1;
      break;
    }
    cutTemp = queueNode;
    queueNode = queueNode->next;
  }
  if (found) {
    cutTemp->next = queueNode->next;
    free(queueNode);
    printf("\n[QUEUE] Eleman listede bulundu ve silindi.");
  } else
    printf("\n[QUEUE] Listede eleman bulunamadi.");
  queueNode = startTemp;
}

// queue find and show (4-3)
void findAndShowQueue(int* find) {
  struct Node* startTemp = queueNode;
  int found = 0;
  while (queueNode != NULL) {
    if (queueNode->value == *find) {
      found = 1;
      break;
    }
    queueNode = queueNode->next;
  }
  if (found) {
    showViewQueue(find);
    printf("\n[QUEUE] Eleman listede bulundu.");
  } else
    printf("\n[QUEUE] Listede eleman bulunamadi.");
  queueNode = startTemp;
}

// queue end

// tools
int getValue(char* message) {
  printf("%s :", message);
  int temp;
  scanf("%d", &temp);
  return temp;
}

// showview (4)
void showview() {
  showViewStack(NULL);
  showViewQueue(NULL);
}

// runtime
int main() {
  while (1) {
    printf("\n\n1-Yeni eleman ekle");
    printf("\n2-Bir eleman bul ve sil");
    printf("\n3-Bir eleman bul ve göster");
    printf("\n4-Tüm elemanlarý listele");
    printf("\n5-Programý sonlandir");
    printf("\nSecim: ");
    int input;
    scanf("%d", &input);
    if (input == 1) {
      int value = getValue("\nEklemek icin bir deger girin");
      addStack(&value);
      addQueue(&value);
    }
    if (input == 2) {
      int value = getValue("\nBulunacak eleman icin bir deger girin");
      findAndRemoveStack(&value);
      findAndRemoveQueue(&value);
    }
    if (input == 3) {
      int value = getValue("\nBulunacak eleman icin bir deger girin");
      findAndShowStack(&value);
      findAndShowQueue(&value);
    }
    if (input == 4) {
      showview();
    }
    if (input == 5) return 0;
  }
  return 0;
}