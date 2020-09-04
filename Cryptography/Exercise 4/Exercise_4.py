def ECpoints(a,b,p):
    points = []
    for x in range (0,p):
        for y in range (0,p):
            lhs = pow(y,2,p)
            rhs = (pow(x,3,p) + a*x + b) % p
            if(lhs == rhs):
                points.append((x,y))
    return points

def powerElements(a,p):
    powers = []
    for i in range (1,p):
        power = pow(a,i,p)
        if power not in powers:
            powers.append(power)
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
  
def DHP(alpha,a,b,p):
    ans = dict()
    ans['KpubA'] = pow(alpha,a,p)
    ans['KpubB'] = pow(alpha,b,p)

    ans['Kab'] = pow(ans['KpubB'],a,p)
    ans['Kba'] = pow(ans['KpubA'],b,p)

    return ans

def primeCheck(number):
    k=0
    for i in range(2,number//2+1):
        if(number%i==0):
            k=k+1
    if(k<=0):
        return True
    else:
        return False

def primeFactors(number):
    factors = []
    for i in range(2, number + 1):
        if(number % i == 0):
            prime = True
            for j in range(2, (i//2 + 1)):
                if(i % j == 0):
                    prime = False
                    break               
            if (prime):
                factors.append(i)
    return factors

def e4p13():
    for p in range (11,29+1):
        if(primeCheck(p)):
            points = ECpoints(1,1,p)
            print("Prime number: {0}" .format(p))
            print("Number of points: {0}" .format(len(points)))
            print("Points: {0}" .format(points))
            print()

def e4p2():
    a = 97
    b = 233
    p = 1997
    primitive = 21
    powers = powerElements(primitive,p)
    # primitives = primitveElements(p)
    # print("Primitives of {0}: {1}" .format(p,primitives))
    # print(DHP(primitives[1],97,233,p))
    print("Proof that {0} is a primitive element of {1}:\nNumber of Power elements for {0}: {2}\nPower Elements of {0}: {3}" .format(primitive,p,len(powers),powers))
    print("For Prime number {0} and primitive {1} for private key a:{2} and b:{3}, the Diffie-Hellman Key Exchange outputs: {4}" .format(p,primitive,a,b,DHP(primitive,a,b,p)))

def e4p3():
    a = 97
    b = 233
    p = 1000000+336+21
    primitive = 2
    dhke = DHP(primitive,a,b,p)
    pFactors = primeFactors(p-1)
    check = []
    for i in range(0,len(pFactors)):
        check.append(pow(primitive,int((p-1)/pFactors[i]),p))
    # powers = powerElements(primitive,p)
    # primitives = primitveElements(p)
    # print("Primitives of {0}: {1}" .format(p,primitives))
    # print(DHP(primitives[1],a,b,p))
    print("Proof that {0} is a primitive element of {1}" .format(primitive,p))
    for i in range(0,len(pFactors)):
        print("{0}^({1}/{2}) = {0}^({3}) = {4} mod {5} != 1 mod {5}" .format(primitive,p-1,pFactors[i],int((p-1)/pFactors[i]),check[i],p))
    print("For Prime number {0} and primitive {1} for private key a:{2} and b:{3}, the Diffie-Hellman Key Exchange outputs: {4}" .format(p,primitive,a,b,dhke))

def e4p4():
    for p in range (100,200+1):
        if(primeCheck(p)):
            primitives = primitveElements(p)
            print("Prime number: {0}" .format(p))
            print("Number of Primitives: {0}" .format(len(primitives)))
            print("Primitives: {0}" .format(primitives))
            print()

part = "start"
while(part != "exit"):
    part = input("Which question would you like to display? [13, 2, 3, or 4]: ")
    if(part == "13"):
        e4p13()
    elif(part == "2"):
        e4p2()
    elif(part == "3"):
        e4p3()
    elif(part == "4"):
        e4p4()
    elif(part == "all"):
        e4p13()
        e4p2()
        e4p3()
        e4p4()
