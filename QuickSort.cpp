#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void swap(int* from, int* to) {
  int temp = *from;
  *from = *to;
  *to = temp;
}

int sortQuickHalf(int* array, int from, int to, int smallToLarge) {
  int pivot = array[to];
  int i = (from - 1);
  for (int j = from; j < to; j++) {
    if (smallToLarge == 1 && array[j] < pivot) swap(&array[++i], &array[j]);
    if (smallToLarge == 0 && array[j] > pivot) swap(&array[++i], &array[j]);
  }
  swap(&array[i + 1], &array[to]);
  return (i + 1);
}

void sortQuick(int* array, int from, int to, int smallToLarge) {
  if (from < to) {
    int seperator = sortQuickHalf(array, from, to, smallToLarge);
    sortQuick(array, from, seperator - 1, smallToLarge);
    sortQuick(array, seperator + 1, to, smallToLarge);
  }
}

int main(void) {
  int array[100];
  srand(time(NULL));
  printf("From:\n");
  for (int index = 0; index < 100; index++) {
    array[index] = rand() % 100;
    printf("%d%s", array[index], index == 50 ? "\t-\t" : "\t");
  }
  printf("\n");
  sortQuick(array, 0, 50, 1);    // 0 - 50 | largeToSmall
  sortQuick(array, 50, 100, 0);  // 50 - 100 | smallToLarge
  printf("To:\n");
  for (int index = 0; index < 100; index++) {
    printf("%d%s", array[index], index == 50 ? "\t-\t" : "\t");
  }
  return 0;
}