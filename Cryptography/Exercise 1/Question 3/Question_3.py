import string, csv
import matplotlib.pyplot as plt

def characterOccurrence(filename):
    characterIndex = dict.fromkeys(string.ascii_lowercase, 0)
    with open(filename) as fileobj:
        for line in fileobj:  
            for ch in line:
                if ch in characterIndex:
                    characterIndex[ch] += 1
    return characterIndex

def dictionary2csv(dictionary, filename):
    w = csv.writer(open(filename, "w"))
    w.writerow([filename])
    for key, val in dictionary.items():
        w.writerow([key, val])

def dictionary2plot(dictionary, name):
    plt.figure(name)
    plt.bar(range(len(dictionary)), list(dictionary.values()), align='center')
    plt.xticks(range(len(dictionary)), list(dictionary.keys()))
    plt.title(name)
    plt.show()

hamlet = characterOccurrence("Hamlet.txt")
julius_caesar = characterOccurrence("Julius_Caesar.txt")
king_lear = characterOccurrence("King_Lear.txt")
macbeth = characterOccurrence("Macbeth.txt")
merchant = characterOccurrence("Merchant.txt")

# dictionary2csv(hamlet, "hamlet.csv")
# dictionary2csv(julius_caesar, "julius_caesar.csv")
# dictionary2csv(king_lear, "king_lear.csv")
# dictionary2csv(macbeth, "macbeth.csv")
# dictionary2csv(merchant, "merchant.csv")

# dictionary2plot(hamlet,"Hamlet Character Occurrence")
# dictionary2plot(julius_caesar,"Julius Caesar Character Occurrence")
# dictionary2plot(king_lear,"King Lear Character Occurrence")
# dictionary2plot(macbeth,"Macbeth Character Occurrence")
# dictionary2plot(merchant,"Merchant Character Occurrence")

plt.figure("Character Occurrences")
plt.subplot(3,2,1)
plt.bar(range(len(hamlet)), list(hamlet.values()), align='center')
plt.xticks(range(len(hamlet)), list(hamlet.keys()))
plt.title("Hamlet")
plt.subplot(3,2,2)
plt.bar(range(len(julius_caesar)), list(julius_caesar.values()), align='center')
plt.xticks(range(len(julius_caesar)), list(julius_caesar.keys()))
plt.title("Julius Caesar")
plt.subplot(3,2,3)
plt.bar(range(len(king_lear)), list(king_lear.values()), align='center')
plt.xticks(range(len(king_lear)), list(king_lear.keys()))
plt.title("King Lear")
plt.subplot(3,2,4)
plt.bar(range(len(macbeth)), list(macbeth.values()), align='center')
plt.xticks(range(len(macbeth)), list(macbeth.keys()))
plt.title("Macbeth")
plt.subplot(3,2,5)
plt.bar(range(len(merchant)), list(merchant.values()), align='center')
plt.xticks(range(len(merchant)), list(merchant.keys()))
plt.title("Merchant")
plt.show()