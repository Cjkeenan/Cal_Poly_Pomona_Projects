def minPowMod(a,n,ans):
    i = 1
    while(True):
        temp = pow(a,i,n)
        if(temp == ans):
            break
        if(i > 1000000):
            break
        else:
            i += 1
    if(i < 1000001):
        return ("{0}^{1} (mod {2}) = {3}" .format(a,i,n,ans))
    else:
        return ("Not Found with {0} iterations" .format(i))

def powMod(a, n):
    i = 1
    ans = []
    while(True):
        temp = pow(a,i,n)
        if temp not in ans:
            ans.append(temp)
        if(i == n):
            break
        else:
            i += 1
    return ans

print("Question 1:")
print("Powers of 3 (mod 17):")
print(powMod(3,17))
print("Smallest integer n such that 3^n = 1 (mod 17):")
print(minPowMod(3,17,1))
print("Smallest integer k such that 3^k = -1(16) (mod 17):")
print(minPowMod(3,17,16))
print("All powers of 3 (mod 17) sorted:")
print(sorted(powMod(3,17)))

print("Question 2:")
print("Powers of 3 (mod 26):")
print(powMod(3,26))
print("Powers of 2 (mod 26):")
print(powMod(2,26))
print("Smallest integer n such that 2^n = 1 (mod 26):")
print(minPowMod(2,26,1))