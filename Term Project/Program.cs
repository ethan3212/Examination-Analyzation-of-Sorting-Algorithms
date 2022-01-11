using System;
using System.Diagnostics;
using System.IO;
using static System.Console;

namespace Term_Project
{
    class Program
    {
        static string input;
        static int loopCount = 0;
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            StreamWriter csv = new StreamWriter("stats.csv");
            // header line
            csv.WriteLine("Method, Input Class, Average Loop Count, Average Time");

            // array of files to be read
            string[] fileName = 
                {
                @"C:\Users\ethan\source\repos\Term Project\Text Files\Double Random Numbers 100.txt",
                @"C:\Users\ethan\source\repos\Term Project\Text Files\Random Numbers 100.txt",
                @"C:\Users\ethan\source\repos\Term Project\Text Files\Reverse Sorted Numbers 100.txt",
                @"C:\Users\ethan\source\repos\Term Project\Text Files\Sorted Numbers 100.txt",
                @"C:\Users\ethan\source\repos\Term Project\Text Files\Double Random Numbers 500.txt",
                @"C:\Users\ethan\source\repos\Term Project\Text Files\Random Numbers 500.txt",
                @"C:\Users\ethan\source\repos\Term Project\Text Files\Reverse Sorted Numbers 500.txt",
                @"C:\Users\ethan\source\repos\Term Project\Text Files\Sorted Numbers 500.txt",
                @"C:\Users\ethan\source\repos\Term Project\Text Files\Double Random Numbers 1000.txt",
                @"C:\Users\ethan\source\repos\Term Project\Text Files\Random Numbers 1000.txt",
                @"C:\Users\ethan\source\repos\Term Project\Text Files\Reverse Sorted Numbers 1000.txt",
                @"C:\Users\ethan\source\repos\Term Project\Text Files\Sorted Numbers 1000.txt",

                };

            // array of "trys" for 95% confidence level
            int[] TRYS = 
                {
                82,
                82,
                82,
                82,
                82,
                458,
                458,
                458,
                458,
                458,
                940,
                940,
                940,
                940,
                940 
                };

            // iterate through all files
            for (int i = 0; i < fileName.Length; i++)
            {
                int inputClass = i;
                int trys = TRYS[i];

                // open the file
                StreamReader sr = null;
                sr = File.OpenText(fileName[inputClass]);

                // read the first line of the file
                string buf = sr.ReadLine();

                // use first line as array size
                int N = Convert.ToInt32(buf);

                // initialize array "raw array"
                int[] rawArray = new int[N];
                int j = 0;

                // while there is still a line to read
                while ((buf = sr.ReadLine()) != null)
                {
                    // that line becomes the next element in the array
                    int num = int.Parse(buf);
                    rawArray[j] = num;
                    j++;
                }   // end while

                // burn and display each sort routine
                if(i == 0)
                {
                    // display raw array
                    displayArray(rawArray);

                    //copy raw array and conduct insertion sort
                    int[] burnArray1 = (int[])rawArray.Clone();
                    InsertionSort(burnArray1, N);
                    displayArray(burnArray1);

                    // copy raw array and conduct bubble sort
                    int[] burnArray2 = (int[])rawArray.Clone();
                    BubbleSort(burnArray2, N);
                    displayArray(burnArray2);

                    // copy raw array and conduct shell sort
                    int[] burnArray3 = (int[])rawArray.Clone();
                    ShellSort(burnArray3, N);
                    displayArray(burnArray3);

                    // copy raw array and conduct radix sort
                    int[] burnArray4 = (int[])rawArray.Clone();
                    RadixSort(burnArray4, N);
                    displayArray(burnArray4);

                    // copy raw array and conduct heap sort
                    int[] burnArray5 = (int[])rawArray.Clone();
                    HeapSort(burnArray5, N - 1);
                    displayArray(burnArray5);

                    // copy raw array and conduct merge sort
                    int[] burnArray6 = (int[])rawArray.Clone();
                    MergeSort(burnArray6, 0, N - 1);
                    displayArray(burnArray6);

                    // copy raw array and conduct quick sort
                    int[] burnArray7 = (int[])rawArray.Clone();
                    QuickSort(burnArray7, 0, N - 1);
                    displayArray(burnArray7);
                }   // end if
            
                // insertion sort
                double ms = 0;

                for (int a = 0; a < trys; a++)
                {
                    input = (fileName[i]);  // grab file name
                    loopCount = 0;  // reset loop counter
                    int[] copiedArray = (int[])rawArray.Clone();    // copy raw array
                    sw.Restart();   // restart stopwatch
                    InsertionSort(copiedArray, N);  // conduct sort routine
                    sw.Stop();  // stop stopwatch
                    ms += sw.Elapsed.TotalMilliseconds; // add total elapsed time

                }   // end for

                WriteLine("Insertion Sort Average Loop Count: " + (loopCount / trys));
                WriteLine("Insertion Sort Average Time: " + (ms / trys));
                csv.WriteLine("Insertion" + "," + input + "," + (loopCount / trys) + "," + (ms / trys));    // write information to CSV file
                WriteLine();

                // bubble sort
                ms = 0;

                for (int a = 0; a < trys; a++)
                {
                    input = (fileName[i]);
                    loopCount = 0;
                    int[] copiedArray = (int[])rawArray.Clone();
                    sw.Restart();
                    BubbleSort(copiedArray, N);
                    sw.Stop();
                    ms += sw.Elapsed.TotalMilliseconds;

                }   // end for

                WriteLine("Bubble Sort Loop Count: " + (loopCount / trys));
                WriteLine("Bubble Sort Average Time: " + (ms / trys));
                csv.WriteLine("Bubble" + "," + input + "," + (loopCount / trys) + "," + (ms / trys));
                WriteLine();

                // shell sort
                ms = 0;

                for (int a = 0; a < trys; a++)
                {
                    input = (fileName[i]);
                    loopCount = 0;
                    int[] copiedArray = (int[])rawArray.Clone();
                    sw.Restart();
                    ShellSort(copiedArray, N);
                    sw.Stop();
                    ms += sw.Elapsed.TotalMilliseconds;

                }   // end for

                WriteLine("Shell Sort Loop Count: " + (loopCount / trys));
                WriteLine("Shell Sort Average Time: " + (ms / trys));
                csv.WriteLine("Shell" + "," + input + "," + (loopCount / trys) + "," + (ms / trys));
                WriteLine();

                // radix sort
                ms = 0;

                for (int a = 0; a < trys; a++)
                {
                    input = (fileName[i]);
                    loopCount = 0;
                    int[] copiedArray = (int[])rawArray.Clone();
                    sw.Restart();
                    RadixSort(copiedArray, N);
                    sw.Stop();
                    ms += sw.Elapsed.TotalMilliseconds;

                }   // end for

                WriteLine("Radix Sort Loop Count: " + (loopCount / trys));
                WriteLine("Radix Sort Average Time: " + (ms / trys));
                csv.WriteLine("Radix" + "," + input + "," + (loopCount / trys) + "," + (ms / trys));
                WriteLine();

                // heap sort
                ms = 0;

                for (int a = 0; a < trys; a++)
                {
                    input = (fileName[i]);
                    loopCount = 0;
                    int[] copiedArray = (int[])rawArray.Clone();
                    sw.Restart();
                    HeapSort(copiedArray, N - 1);
                    sw.Stop();
                    ms += sw.Elapsed.TotalMilliseconds;

                }   // end for

                WriteLine("Heap Sort Loop Count: " + (loopCount / trys));
                WriteLine("Heap Sort Average Time: " + (ms / trys));
                csv.WriteLine("Heap" + "," + input + "," + (loopCount / trys) + "," + (ms / trys));
                WriteLine();

                //merge sort
                ms = 0;

                for (int a = 0; a < trys; a++)
                {
                    input = (fileName[i]);
                    loopCount = 0;
                    int[] copiedArray = (int[])rawArray.Clone();
                    sw.Restart();
                    MergeSort(copiedArray, 0, N - 1);
                    sw.Stop();
                    ms += sw.Elapsed.TotalMilliseconds;

                }   // end for

                WriteLine("Merge Sort Loop Count: " + (loopCount / trys));
                WriteLine("Merge Sort Average Time: " + (ms / trys));
                csv.WriteLine("Merge" + "," + input + "," + (loopCount / trys) + "," + (ms / trys));
                WriteLine();

                // quick sort
                ms = 0;

                for (int a = 0; a < trys; a++)
                {
                    input = (fileName[i]);
                    loopCount = 0;
                    int[] copiedArray = (int[])rawArray.Clone();
                    sw.Restart();
                    QuickSort(copiedArray, 0, N - 1);
                    sw.Stop();
                    ms += sw.Elapsed.TotalMilliseconds;

                }   // end for

                WriteLine("Quick Sort Loop Count: " + (loopCount / trys));
                WriteLine("Quick Sort Average Time: " + (ms / trys));
                csv.WriteLine("Quick" + "," + input + "," + (loopCount / trys) + "," + (ms / trys));
                WriteLine();

            }   // end for

            // close the CSV writer
            csv.Close();

            // wait
            ReadLine();

        }   // end main()

        static void InsertionSort(int[] list, int max)
        {
            for (int i = 1; i < max; i++)
            {
                int newElement = list[i];
                int location = i - 1;

                while ((location >= 0) && (list[location] > newElement))
                {
                    loopCount++;
                    list[location + 1] = list[location];
                    location = location - 1;

                }   // end while

                list[location + 1] = newElement;

            }   // end for

        }   // end InsertionSort

        static void BubbleSort(int[] list, int N)
        {
            int numberOfPairs = N;
            bool swappedElements = true;

            while (swappedElements)
            {
                numberOfPairs = numberOfPairs - 1;
                swappedElements = false;

                for (int i = 0; i < numberOfPairs; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        loopCount++;
                        Swap(list, i, (i + 1));
                        swappedElements = true;

                    }   // end if

                }   // end for

            }   // end while

        }   // end BubbleSort

        static void ShellSort(int[] list, int N)
        {
            int passes = Convert.ToInt32(Math.Log(N));

            while (passes >= 0)
            {
                int increment = (2 ^ passes) - 1;

                for (int start = 0; start < N; start++)
                {
                    loopCount++;
                    SpecialInsertionSort(list, N, start, increment);

                }   // end for

                passes = passes - 1;

            }   // end while

        }   // end ShellSort()

        static void RadixSort(int[] list, int N)
        {
            int digitplace = 1;
            int[] result = new int[N];
            int largestNum = GetMax(list, N);

            while ((largestNum / digitplace) > 0)
            {
                int[] count = new int[10];

                for (int i = 0; i < N; i++)
                {
                    loopCount++;
                    count[(list[i] / digitplace) % 10] = count[(list[i] / digitplace) % 10] + 1;

                }   // end for

                for (int i = 1; i < 10; i++)
                {
                    loopCount++;
                    count[i] = count[i] + count[i - 1];

                } // end for

                for (int i = N - 1; i >= 0; i--)
                {
                    loopCount++;
                    result[count[(list[i] / digitplace) % 10] - 1] = list[i];
                    count[(list[i] / digitplace) % 10] = count[(list[i] / digitplace) % 10] - 1;

                }   // end for

                for (int i = 0; i < N; i++)
                {
                    list[i] = result[i];

                }   // end for

                digitplace = digitplace * 10;

            }   // end while

        }   // end RadixSort()

        static void HeapSort(int[] list, int N)
        {
            for (int i = (N / 2); i >= 0; i--)
            {
                loopCount++;
                FixHeap(list, i, list[i], N);

            }   // end for

            for (int i = (N - 1); i >= 0; i--)
            {
                loopCount++;
                Swap(list, (i + 1), 0);
                FixHeap(list, 0, list[0], i);

            }   // end for

        }   // end HeapSort()

        static void MergeSort(int[] list, int first, int last)
        {
            loopCount++;

            if (first < last)
            {            
                int middle = (first + last) / 2;
                MergeSort(list, first, middle);
                MergeSort(list, (middle + 1), last);
                MergeLists(list, first, middle, (middle + 1), last);

            }   // end if

        }   // end MergeSort()

        static void QuickSort(int[] list, int first, int last)
        {
            if (first < last)
            {
                int pivot = PivotList(list, first, last);
                loopCount++;
                QuickSort(list, first, (pivot));
                loopCount++;
                QuickSort(list, (pivot + 1), last);

            }   // end if

        }   // end QuickSort()

        static void Swap(int[] list, int i, int j)
        {
            loopCount++;
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;

        }   // end Swap()
        static void SpecialInsertionSort(int[] list, int N, int start, int increment)
        {
            int newElement = list[start];
            int location = start;

            for (int i = 0; i < increment; i++)
            {
                while ((location >= increment) && (list[(location - increment)] > newElement))
                {
                    list[location] = list[location - increment];
                    location = location - increment;

                }   // end while

                list[location] = newElement;

            }   // end for

        }   // end SpecialInsertionSort()

        static int GetMax(int[] list, int N)
        {
            // initiate "max"
            int max = -1;

            // iterate through list
            for (int i = 0; i <= N; i++)
            {
                // if element is larger than current max
                if (i > max)
                {
                    loopCount++;

                    //increase max
                    max = i;

                }   // end if

            }   // end for

            // return the largest number
            return max;

        }   // end GetMax()

        static void FixHeap(int[] list, int root, int key, int bound)
        {
            int vacant = root;

            while ((2 * vacant) <= bound)
            {
                int largerChild = 2 * vacant;

                if ((largerChild < bound) && (list[largerChild + 1] > list[largerChild]))
                {
                    loopCount++;
                    largerChild = largerChild + 1;

                }   // end if


                // if the element is larger
                if (key >= list[largerChild])
                {
                    break;

                }   // end if

                else
                {
                    loopCount++;
                    list[vacant] = list[largerChild];
                    vacant = largerChild;

                }   // end else

            }   // end while

            list[vacant] = key;

        }   // end fixHeap()

        static void MergeLists(int[] list, int start1, int end1, int start2, int end2)
        {
            loopCount++;
            int[] result = new int[list.Length];

            // set points for merge based on list length
            int finalStart = start1;
            int finalEnd = end2;

            // set index
            int indexC = 0;

            // iterate through the lists
            while ((start1 <= end1) && (start2 <= end2))
            {
                // if element is smaller
                if (list[start1] < list[start2])
                {
                    loopCount++;
                    result[indexC] = list[start1];
                    start1++;

                }   // end if

                // if element is bigger
                else
                {
                    loopCount++;
                    result[indexC] = list[start2];
                    start2++;

                }   // end else

                // increase the index
                indexC++;

            }   // end while

            if (start1 <= end1)
            {
                for (int i = start1; i <= end1; i++)
                {
                    loopCount++;
                    result[indexC] = list[i];
                    indexC++;

                }   // end for

            }   // end if

            else
            {
                for (int i = start2; i <= end2; i++)
                {
                    loopCount++;
                    result[indexC] = list[i];
                    indexC++;

                }   // end for

            }   // end else

            indexC = 0;

            for (int i = finalStart; i <= finalEnd; i++)
            {
                list[i] = result[indexC];
                indexC++;

            }   // end for

        }   // end MergeLists()

        static int PivotList(int[] list, int first, int last)
        {
            // set pivot points
            int PivotValue = list[first];
            int PivotPoint = first;

            for (int index = (first + 1); index <= last; index++)
            {
                // locate pivot point
                if (list[index] < PivotValue)
                {
                    // change the pivot point
                    loopCount++;
                    PivotPoint = PivotPoint + 1;
                    Swap(list, PivotPoint, index);

                }   // end if

            }   // end for

            // Swap
            Swap(list, first, PivotPoint);
            return PivotPoint;

        }   // end PivotList()

        static void displayArray(int[] list)
        {
            // Set "N" to current length of array
            int N = list.Length;

            // for each element in the list
            foreach (int i in list)
            {
                // display it
                Write(i + " ");

            }   // end foreach

            WriteLine();
            WriteLine();

        }   // end displayArray()
    }
}