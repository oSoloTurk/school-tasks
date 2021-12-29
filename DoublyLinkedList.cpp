#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>
#include <time.h>

struct Node {
    int value;
    struct Node* previous;
    struct Node* next;
};

struct Node* list = NULL;

void addList(int* value) {
    struct Node* newNode = (struct Node*)malloc(sizeof(struct Node));
    newNode->value = *value;
    if (list == NULL) {
        newNode->previous = NULL;
        newNode->next = NULL;
    }
    else {
        list->previous = newNode;
    }
    newNode->next = list;
    list = newNode;
}

void removeList(int* find) {
    struct Node* temp = list;
    while (1) {
        if (temp->value == *find) {
            if (temp->previous == NULL) list = temp->next;
            else temp->previous->next = temp->next;
            free(temp);
            break;
        }
        temp = temp->next;
        if (temp->next == NULL) {
            printf("Aranan eleman listede bulunamadi.");
            break;
        }
    }
}

void printlist() {
    struct Node* temp = list;
    printf("\n [");
    while (1) {
        if (temp->next == NULL) {
            printf("%d]", temp->value);
            break;
        }
        else printf("%d <-> ", temp->value);
        temp = temp->next;
    }
    printf("\n");
}

int main(void) {
    srand(time(NULL));
    for (int index = 0; index < 20; index++) {
        int randomValue = rand() % 150;
        addList(&randomValue);
    }
    printf("Rastgele sayilardan bir liste olusturuldu:");
    printlist();
    char status = 'y';
    while (status == 'y' || status == 'Y') {
        printf("\nListeden silinecek degeri girin: ");
        int input;
        scanf("%d", &input);
        removeList(&input);
        printlist();
        printf("\ny/n : ");
        scanf("%s", &status);
    }
    return 0;
}