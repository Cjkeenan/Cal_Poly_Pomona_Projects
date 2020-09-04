import cProfile
import re

def ECpoints(a,b,p):
    points = []
    for x in range (0,p):
        rhs = (pow(x,3) + a*x + b) % p
        for y in range (0,p):
            lhs = (pow(y,2,p))
            if(rhs == lhs):
                points.append((x,y))
    return points

def primeCheck(number):
    k=0
    for i in range(2,number//2+1):
        if(number%i==0):
            k=k+1
    if(k<=0):
        return True
    else:
        return False

def powerElements(a,p):
    powers = []
    for i in range (1,p):
        power = pow(a,i,p)
        if power not in powers:
            powers.append(power)
        else:
            return powers
    return powers

def cyclicGroupOrder(p):
    order = []
    for i in range (1,p):
        powers = powerElements(i,p)
        order.append(len(powers))
    return order

def primitveElements(p):
    primitive = []
    for i in range (1,p):
        powers = powerElements(i,p)
        if(len(powers) == (p-1)):
            primitive.append(i)
    return primitive

def primitveElements(p,limit):
    primitive = []
    for i in range (1,p):
        powers = powerElements(i,p)
        if(len(powers) == (p-1)):
            primitive.append(i)
        if(len(primitive) == limit):
            return primitive

def eccProblem():
    for p in range (91,100+1):
        if(primeCheck(p)):
            points = ECpoints(1,1,p)
            print("Prime number: {0}" .format(p))
            print("Number of points: {0}" .format(len(points)))
            print("Points: {0}\n" .format(points))

    for p in range (1997,1999+1):
        if(primeCheck(p)):
            points = ECpoints(1,1,p)
            print("Prime number: {0}" .format(p))
            print("Number of points: {0}\n" .format(len(points)))

    p = 1000003
    if(primeCheck(p)):
        points = ECpoints(1,1,p)
        print("Prime number: {0}" .format(p))
        print("Number of points: {0}\n" .format(len(points)))

def primitiveRootsProblem():
    numbers = [101,103,1997,1000003]
    roots = []

    for i in range(0,len(numbers)):
        if(i <= 1):
            roots.append(primitveElements(numbers[i],5))
        else:
            roots.append(primitveElements(numbers[i],1))
        print("Primitive Roots of {0}: {1}" .format(numbers[i],roots))
        roots.clear()

def euclidAlgo(larger, smaller):
    if(smaller > larger):
        temp = larger
        larger = smaller
        smaller = temp
    
    rem = larger % smaller

    if(rem == 0):
        return smaller
    
    return euclidAlgo(smaller, rem)

# cProfile.run('primitiveRootsProblem()')
# eccProblem()

p = 1997
points = ECpoints(1,1,p)
print("Prime number: {0}" .format(p))
print("Number of points: {0}" .format(len(points)))