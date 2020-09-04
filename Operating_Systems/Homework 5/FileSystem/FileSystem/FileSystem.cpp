// fileSystem.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "FileDirectory.h"

int _tmain(int argc, _TCHAR* argv[])
{
	FileDirectory	fileDirectory;
	char data[1024];
	for (int i = 0; i < 1024; i++) data[i] = i;

	//	Write a driver function, i.e.main(), to test this program by
	//1.	create and write a file, file1, of 40 bytes,
	if (fileDirectory.create(40))
	{
		fileDirectory.write((char*)"file1", 40, data, 2019, 4, 16, 15, 29, 30);
	}

	//2.	create and write a file, file2, of 200 bytes,
	if (fileDirectory.create(200))
	{
		fileDirectory.write((char*)"file2", 200, data, 2019, 4, 16, 15, 29, 30);
	}

	//fileDirectory.printDirectory();

	//3.	create and write a file, file3, of 300 bytes,
	if (fileDirectory.create(300))
	{
		fileDirectory.write((char*)"file3", 300, data, 2019, 4, 16, 15, 29, 30);
	}

	//4.	delete file2
	fileDirectory.printDirectory();
	fileDirectory.deleteFile((char*)"file2");

	//5.	create and write a file, file4, of 500 bytes.
	if (fileDirectory.create(100))
	{
		fileDirectory.write((char*)"file4", 100, data, 2019, 4, 16, 15, 29, 30);
	}

	//6.	create and write a file, file4, of 500 bytes.
	if (fileDirectory.create(500))
	{
		fileDirectory.write((char*)"file5", 500, data, 2019, 4, 16, 15, 29, 30);
	}
	
	
	fileDirectory.printDirectory();

	fileDirectory.write((char*)"file4", 150, data, 2019, 4, 16, 15, 29, 30);
	fileDirectory.write((char*)"file4", 113, data, 2019, 4, 16, 15, 29, 30);

	fileDirectory.printDirectory();
	printf("\nfile1 sector list\n");
	fileDirectory.printClusters((char*)"file1");
	fileDirectory.printData((char*)"file1");
	printf("\nfile2 sector list\n");
	fileDirectory.printClusters((char*)"file2");
	printf("\nfile3 sector list\n");
	fileDirectory.printClusters((char*)"file3");
	printf("\nfile4 sector list\n");
	fileDirectory.printClusters((char*)"file4");

	

	fileDirectory.deleteFile((char*)"file3");
	fileDirectory.deleteFile((char*)"file4");
	fileDirectory.deleteFile((char*)"file2");
	fileDirectory.deleteFile((char*)"file1");

	fileDirectory.printDirectory();
	printf("\nfile1 sector list\n");
	fileDirectory.printClusters((char*)"file1");
	printf("\nfile2 sector list\n");
	fileDirectory.printClusters((char*)"file2");
	printf("\nfile3 sector list\n");
	fileDirectory.printClusters((char*)"file3");
	printf("\nfile4 sector list\n");
	fileDirectory.printClusters((char*)"file4");
	printf("\nfile5 sector list\n");
	fileDirectory.printClusters((char*)"file5");

	return 0;
}