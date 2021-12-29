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

void addStack(int* input) {
  struct Node* newNode = (struct Node*)malloc(sizeof(struct Node));
  newNode->value = *input;
  if (stackNode == NULL)
    newNode->next = NULL;
  else
    newNode->next = stackNode;
  stackNode = newNode;
}

void removeStack() {
  printf(" - %d ", stackNode->value);
  struct Node* temp = stackNode;
  stackNode = stackNode->next;
  free(temp);
}

// stack end

// queue start

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

void removeQueue() {
  if (queueNode->next == NULL) {
    printf(" - %d ", queueNode->value);
    queueNode = NULL;
  } else {
    struct Node* temp = queueNode;
    while (temp->next->next != NULL) temp = temp->next;
    printf(" - %d ", temp->next->value);
    free(temp->next);
    temp->next = NULL;
  }
}

// queue end

// runtime

int main() {
  char status = 'y';
  while (status == 'y' || status == 'Y') {
    printf("\nListeye Eklenecek Girdiyi Giriniz: ");
    int input;
    scanf("%d", &input);
    addStack(&input);
    addQueue(&input);
    printf("\ny/n : ");
    scanf("%s", &status);
  }
  printf("\nStack Ciktisi (Top): ");
  while (1) {
    if (stackNode == NULL) break;
    removeStack();
  }
  printf("-");
  printf("\nQueue Ciktisi (Front): ");
  while (1) {
    if (queueNode == NULL) break;
    removeQueue();
  }
  printf("-");
  return 0;
}