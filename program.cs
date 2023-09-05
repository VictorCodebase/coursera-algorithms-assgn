// See https://aka.ms/new-console-template for more information


//compute number of comparisons needed to sort an input using QuickSort

int[] testData = { 3, 2, 5, 0, 1, 8, 7, 6, 9, 4 };
FetchData fetch = new FetchData();

//Sort sort = new Sort(fetch.fetchRawData());
Sort2 sort = new Sort2(testData);
int[] arranged = sort.quickSort(null, 0, testData.Length - 1);

foreach (int i in arranged)
{
    Console.WriteLine(i);
}


public class Sort
{
    public int[] input { get; set; }
    private int comparisonCount = 0;



    public Sort (int[] input)
    {
        this.input = input;
    }

    public int[] quickSort(int[]? arr, int left, int right)
    {
        if (arr == null)
        {
            arr = this.input;
        }
        if (left < right)
        {
            comparisonCount = arr.Length - 1;
            int partitionPos = partition(arr, left, right); //first item of partition method result is the partition point
            quickSort(arr, left, partitionPos - 1);
            quickSort(arr, partitionPos + 1, right);
        }
        return arr;
    }

    public int partition(int[] arr, int left, int right)
    {
        int i = left + 1;
        int pivot = arr[i];

        for (int j = i; j < right; j++)
        {
            if (arr[j] < pivot)
            {
                (arr[i], arr[j]) = (arr[j], arr[i]); //used tuples to swap values
                i++;
            }
        }

        return i;
    }
}


public class Sort2
{
    public int[] input { get; set; }
    public Sort2(int[] input)
    {
        this.input = input;
    }

    public int[] quickSort(int[]? arr, int left, int right)
    {
        if (arr == null) arr = this.input;
        if (right > left)
        {
            int partitionPoint = partition(arr, left, right);

            quickSort(arr, left, partitionPoint - 1);
            quickSort(arr, partitionPoint + 1, right);
        }
        return arr;
    }

    public int partition(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int orange = arr[left];
        int orangePointer = -1;
        int green = arr[left];

        for(int i = 0; i <= right; i++)
        {
            green = arr[left + i];

            if (green <= pivot)
            {
                orangePointer++;
                orange = arr[orangePointer];
                if(green > orange)
                {
                    (orange, green) = (green, orange);
                }
            }
        }
        return orangePointer;
    }
}


public class FetchData
{
    public int[] fetchRawData()
    {
        string[] lines = File.ReadAllLines("rawData.txt");
        int[] result = new int[lines.Length];

        //im really sorry I did this. I was just too tired to think of anything else - or research 😪
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = int.Parse(lines[i]);
        }

        return result;
    }
}
