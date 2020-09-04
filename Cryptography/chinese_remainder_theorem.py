def chRemTh(mod1, mod2, mod3, ans1, ans2, ans3):
        x = 1
        found = False
        while(found == False):
            temp1 = x % mod1
            temp2 = x % mod2
            temp3 = x % mod3
            if((temp1 == ans1) & (temp2 == ans2) & (temp3 == ans3)):
                found = True
            else:
                x += 1
        return x

def chRemTh(mod1, mod2, ans1, ans2):
        x = 1
        found = False
        while(found == False):
            temp1 = x % mod1
            temp2 = x % mod2
            if((temp1 == ans1) & (temp2 == ans2)):
                found = True
            else:
                x += 1
        return x


def invMod(a, m) : 
    m0 = m 
    x0 = 0
    x1 = 1

    if (m == 1): 
        return 0

    # Apply extended Euclid Algorithm 
    while (a > 1):
        # Make sure you can divide by m, i.e. solution exists
        if(m == 0):
            return None
        # q is quotient 
        q = a // m 

        # m is remainder now, processsame as euclid's algo
        t = m
        m = a % m 
        
        a = t 
        t = x0 
        x0 = x1 - q * x0 
        x1 = t
    
    # Make x1 positive 
    if (x1 < 0) : 
        x1 = x1 + m0 

    return x1 

# k is size of num[] and rem[]. 
# Returns the smallest 
# number x such that: 
# x % num[0] = rem[0], 
# x % num[1] = rem[1], 
# .................. 
# x % num[k-2] = rem[k-1] 
# Assumption: Numbers in num[] 
# are pairwise coprime 
# (gcd for every pair is 1) 
def findMinX(num, rem, k) : 
    # Compute product of all numbers 
    prod = 1
    for i in range(0, k) : 
        prod = prod * num[i] 

    # Initialize result 
    result = 0

    # Apply above formula 
    for i in range(0,k): 
        pp = prod // num[i] 
        inv = invMod(pp, num[i])
        if(inv == None):
            return "Does not exist"
        result = result + rem[i] * inv * pp
    
    return result % prod 

# Driver method 
num = [17, 39] 
rem = [1, 5] 
k = len(num) 
print("x = 1 (mod 17)")
print("x = 5 (mod 39)")
print("x: {0}".format(findMinX(num, rem, k)))
print()

num = [15, 21, 35] 
rem = [1, 2, 3] 
k = len(num) 
print("x = 1 (mod 15)")
print("x = 2 (mod 21)")
print("x = 3 (mod 35)")
print("x: {0}".format(findMinX(num, rem, k)))
print()

num = [2019, 2021] 
rem = [1, 2] 
k = len(num) 
print("x = 1 (mod 2019)")
print("x = 2 (mod 2021)")
print("x: {0}".format(findMinX(num, rem, k)))
print()