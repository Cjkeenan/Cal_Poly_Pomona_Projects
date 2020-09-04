#include "stdafx.h"
#include "FileDirectory.h"
#include <iostream>
#define EOFile 0xFF

//spec: 256 sectors each holding 4 bytes so can hold 1KB of stuff

FileDirectory::FileDirectory()
{
//purpose	: to initialize all entries in the fileDirectory and FAT16 to be 0; i.e.safe values.
	for (int i = 0; i < 4; i++)
	for (int j = 0; j < 32; j++) fileDirectory[i][j] = 0;
	for (int i = 0; i < 256; i++) FAT16[i] = 0;
	for (int i = 0; i < 1024; i++) data[i] = 0;
}
bool FileDirectory::create(int numberBytes)
{
//	(1)	to check if there is an unused entry in the File Directory;  (i.e.the first character of the file name in the File Directory is zero).Return false if not true.
	int sectors[256];	//array of unused sectors
	int sectors_count = 0;
	int sectors_needed = numberBytes / 4;
	//look through all sectors
	for (int i = 0; i < 256; i++)
	{
		//if unused (1 or 0), note that sector in the sectors array
		if (FAT16[i] == 0 || FAT16[i] == 1)
		{
			sectors[i] = i;
			sectors_count++;
		}
	}

//	(2)	to check if there are enough unused clusters to store the file with the numberBytes.Return false if not true.
	if (sectors_count >= sectors_needed)
	{
		return true;
	}
	else
	{
		printf("Sorry, not enough space in the FAT table, please provide a file smaller than %d bytes", sectors_count);
		return false;
	}
}
bool FileDirectory::deleteFile(char filename[])
{
//	(0)	to check if the file to be deleted; filename[]; is in the Directory.If not; return false.
	int i, j;
	//look through all files
	for (i = 0; i < 4; i++){
		//look through all characters of a given file
		for (j = 0; j < 8; j++)
		{
			//check if every character of the filename in FAT is the same as the file intended to be deleted
			if (fileDirectory[i][j] != filename[j])break;
		}
		if (j == 8) break;
	}
	//no match found, return false
	if (i == 4)
	{
		printf("\n%s cannot be deleted: File not Found\n", filename);
		return false;
	}

//	(1)	to change the first character of the file name in the File Directory to be zero;
	fileDirectory[i][0] = NULL;

//	(2)	to change all entries of the clusters of this file in the FAT to 1; i.e.; unused.
	int firstSector = (fileDirectory[i][27] << 8) + fileDirectory[i][26];
	int sectors[256];
	sectors[0] = firstSector;
	int size;

	//fill sectors[] with all sectors used in file
	for (i = 0; FAT16[sectors[i]] != EOFile; i++)
	{
		sectors[i + 1] = FAT16[sectors[i]];
	}
	
	//for each sector used, set the value to 1, ie unused
	for (j = 0; FAT16[sectors[j]] != EOFile; j++)
	{
		FAT16[sectors[j]] = 1;
	}
	FAT16[sectors[j]] = 1;	//delete EOFile sector

	printf("\n%s has been deleted!\n", filename);
}
bool FileDirectory::read(char filename[])
{
//purpose: to read  of data from data[] array from the file with the specified file name.
	//(0)	to check if the file to be read filename[], is in the Directory.If not; return false.
	int i, j;
	int year, month, day, hour, minute, second, date, time;
	int size = 0, sector_address = 0;
	int sectors[256];
	int data_copy[1024];

	//look through all files
	for (int file = 0; file < 4; file++)
	{
		//check if the current file exists
		if (fileDirectory[file][0] == NULL)
		{
			printf("Cannot read: File in location %d not found\n", file + 1);
			return false;
		}
		else
		{
			//get time
			date = (fileDirectory[file][25] << 8) + fileDirectory[file][24];
			year = 1980 + (date >> 9);
			month = (date & 0x01E0) >> 5;	//
			day = date & 0x001F;			//5 LSB
			time = (fileDirectory[file][23] << 8) + fileDirectory[file][22];
			hour = time >> 11;
			minute = (time >> 5) & 0x000F;
			second = (time & 0x001F) << 1;

			//first sector address
			sectors[0] = (fileDirectory[file][27] << 8) + fileDirectory[file][26];

			//get rest of sectors
			for (int k = 0; FAT16[sectors[k]] != EOFile; k++)
			{
				sectors[k + 1] = FAT16[sectors[k]];
			}

			//get file size
			size = fileDirectory[file][31];
			size = size << 8;
			size += fileDirectory[file][30];
			size = size << 8;
			size += fileDirectory[file][29];
			size = size << 8;
			size += fileDirectory[file][28];
			size /= 8;

			//get data
			for (i = 0; FAT16[sectors[i]] != EOFile; i++)
			{
				data_copy[i] = data[sectors[i]];
			}
		}
	}
	return true;
}
bool FileDirectory::write(char filename[], int numberBytes, char data[], int year, int month, int day, int hour, int minute, int second)
{
	//purpose: to write numberBytes bytes of data from data[] array into the file with the specified file name

	int sectors[256] = { EOFile };
	int unused = 0;
	//0. look for unused sectors
	for (int i = 2; i < 255; i++)
	{
		if (FAT16[i] == 0 || FAT16[i] == 1)
		{
			sectors[unused] = i;
			unused++;
		}
	}

	//check if file already exists in the table

	int i, j;
	//look through all files
	for (i = 0; i < 4; i++) {
		//look through all characters of a given file
		for (j = 0; j < 8; j++)
		{
			//check if every character of the filename in FAT is the same as the file intended to be deleted
			if (fileDirectory[i][j] != filename[j])break;
		}
		if (j == 8) break;
	}
	//match found, handle overwrite process
	if (i != 4)
	{
		int old_size = fileDirectory[i][31];
		old_size = old_size << 8;
		old_size += fileDirectory[i][30];
		old_size = old_size << 8;
		old_size += fileDirectory[i][29];
		old_size = old_size << 8;
		old_size += fileDirectory[i][28];
		old_size /= 8;

		int total_usuable_size = unused + old_size;

		//check if there is enough room accounting for the deletion of the old file of same name
		if (numberBytes <= total_usuable_size)
		{
			printf("\n%s overwrite initiated\n", filename);
			deleteFile(filename);
			write(filename, numberBytes, data, year, month, day, hour, minute, second);
		}
		//not enough room even accounting for deleting of old file
		else
		{
			printf("\nNot enough space to overwrite %s, please provide a file of at most %d bytes.\n", filename, total_usuable_size);
		}
	}

	//match not found, continue normal write process
	else
	{
		//(1) write next sector addresses into FAT16.
		int i;
		for (i = 0; i < numberBytes / 4; i++)
		{
			FAT16[sectors[i]] = sectors[i + 1];
		}
		FAT16[sectors[i]] = EOFile;		//write the End of File into the last sector of FAT16.

		//(3)	to write / update the file name, extension, date, time, file length and first cluster address into the first unused entry in the File Directory,
		//3.1 look for an unused entry in the directory
		for (i = 0; i < 4; i++)
		{
			if (fileDirectory[i][0] == 0)break;
		}

		//3.2 if not found, return false,
		if (i == 4) return false;

		//3.3 if found, write all file info into the entry
		//write file name
		for (int j = 0; j < 8; j++)
		{
			fileDirectory[i][j] = filename[j];
		}

		//write date
		int date;
		date = ((year - 1980) << 9) + (month << 5) + day;
		fileDirectory[i][24] = date;
		fileDirectory[i][25] = date >> 8;

		//write time
		int time;
		time = (hour << 11) + (minute << 5) + (second / 2);
		fileDirectory[i][22] = time;
		fileDirectory[i][23] = time >> 8;


		//write file length
		int bits = numberBytes * 8;
		for (int k = 28; k < 32; k++)
		{
			fileDirectory[i][k] = bits & 0x00FF;
			bits = bits >> 8;
		}

		//write first sector address
		fileDirectory[i][26] = sectors[0] & 0x00FF;
		fileDirectory[i][27] = (sectors[0] >> 8) & 0x00FF;

		//write data
		for (i = 0; FAT16[sectors[i]] != EOFile; i++)
		{
			this->data[i] = data[sectors[i]];
		}

		//retun true.
		printf("\n%s has been written!\n", filename);
		return true;
	}
}
void FileDirectory::printClusters(char filename[])
{
	//purpose : to print all the clusters of a file.
	// (1)	to check if the file to be printed, filename[], is in the Directory.If not, return false.
	int i, j;
	//look through all files
	for (i = 0; i < 4; i++) {
		//look through all characters of a given file
		for (j = 0; j < 8; j++)
		{
			//check if every character of the filename in FAT is the same as the file intended to be deleted
			if (fileDirectory[i][j] != filename[j])break;
		}
		if (j == 8) break;
	}
	//no match found, print file not found
	if (i == 4) 
	{
		printf("Cannot print clusters used: %s not found\n", filename);
	}
	else {
		// (2)	use the file name to get the file information from the File Directory, including the first cluster address
		int sectors[256];
		int size;
		sectors[0] = (fileDirectory[i][27] << 8) + fileDirectory[i][26];
		//size = fileDirectory[i][31];
		//size  = size << 8;
		//size += fileDirectory[i][30];
		//size = size << 8;
		//size += fileDirectory[i][29];
		//size = size << 8;
		//size += fileDirectory[i][28];
		//size /= 8;

		// (3)	use the first cluster address to get all cluster addresses from the FAT - 16,
		for (int k = 0; FAT16[sectors[k]] != EOFile; k++)
		{
			sectors[k + 1] = FAT16[sectors[k]];
		}
		//sectors[(size / 4)] = EOFile;

		//print out all used sectors
		for (i = 0; FAT16[sectors[i]] != EOFile; i++)
		{
			if (sectors[i] != EOFile)
			{
				printf("0x%02x -> ", sectors[i]);
			}
			else
			{
				printf("0x%02x.", sectors[i]);
			}
		}
		printf("0x%02x\n", EOFile);
	}
}
void FileDirectory::printDirectory()
{
	//purpose: prints all the  files of the directory.
	// (1)	use the file name to get the file information from the File Directory, including the first cluster address,
	int i, j;
	int year, month, day, hour, minute, second, date, time;
	char filename[8];
	int sectors = 0, size = 0, sector_address = 0;

	printf("\nFAT16 based Directory:\n");	//header

	//look through all files
	for (int file = 0; file < 4; file++)
	{
		//check if the current file exists
		if (fileDirectory[file][0] == NULL)
		{
			printf("File in location %d not found\n", file + 1);
		}
		else
		{
			//get filename
			for (int j = 0; j < 8; j++)
			{
				filename[j] = fileDirectory[file][j];
			}

			//get time
			date = (fileDirectory[file][25] << 8) + fileDirectory[file][24];
			year = 1980 + (date >> 9);
			month = (date & 0x01E0) >> 5;	//
			day = date & 0x001F;			//5 LSB
			time = (fileDirectory[file][23] << 8) + fileDirectory[file][22];
			hour = time >> 11;
			minute = (time >> 5) & 0x000F;
			second = (time & 0x001F) << 1;

			//first sector address
			sector_address = fileDirectory[file][27];
			sector_address << 8;
			sector_address += fileDirectory[file][26];

			//get file size
			size = fileDirectory[file][31];
			size = size << 8;
			size += fileDirectory[file][30];
			size = size << 8;
			size += fileDirectory[file][29];
			size = size << 8;
			size += fileDirectory[file][28];
			size /= 8;

			//get number of sectors used
			sectors = size / 4;

			//print stuff
			printf("%s\t%d/%d/%d\t%d:%d:%d\t%04d bytes\t0x%02x\t%d sectors\n", filename, month, day, year, hour, minute, second, size, sector_address, sectors);
		}
	}
}
void FileDirectory::printData(char filename[])
{
	//purpose: to print the data of a file.
	// (1)	use the file name to get the file information from the File Directory, including the first cluster address,
	int i, j;
	//look through all files
	for (i = 0; i < 4; i++) {
		//look through all characters of a given file
		for (j = 0; j < 8; j++)
		{
			//check if every character of the filename in FAT is the same as the file intended to be deleted
			if (fileDirectory[i][j] != filename[j])break;
		}
		if (j == 8) break;
	}
	//no match found, print file not found
	if (i == 4)
	{
		printf("Cannot print data: %s not found\n", filename);
	}
	else {
		int sectors[256];
		int size;
		sectors[0] = (fileDirectory[i][27] << 8) + fileDirectory[i][26];
		//size = fileDirectory[i][31];
		//size = size << 8;
		//size += fileDirectory[i][30];
		//size = size << 8;
		//size += fileDirectory[i][29];
		//size = size << 8;
		//size += fileDirectory[i][28];
		//size /= 8;

		// (2)	use the first cluster address to get all cluster addresses from the FAT - 16,
		for (int k = 0; FAT16[sectors[k]] != EOFile; k++)
		{
			sectors[k + 1] = FAT16[sectors[k]];
		}
		//sectors[size / 4] = EOFile;

		printf("%s data:\n", filename);
		// (3)	use cluster address to read the data of the file.Use the file length to print these data in hexadecimal format.
		for (i = 0; FAT16[sectors[i]] != EOFile; i++)
		{
			printf("0x%02x ", data[sectors[i]]);
		}
	}
}