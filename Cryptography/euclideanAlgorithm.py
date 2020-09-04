def euclidAlgo(larger, smaller):
    if(smaller > larger):
        temp = larger
        larger = smaller
        smaller = temp
    
    rem = larger % smaller

    if(rem == 0):
        return smaller
    
    return euclidAlgo(smaller, rem)

def extEuclidAlgo(a, b):
    a, b = abs(a), abs(b)
    x0, x1, y0, y1 = 1, 0, 0, 1
    while b != 0:
        q, a, b = a // b, b, a % b
        x0, x1 = x1, x0 - q * x1
        y0, y1 = y1, y0 - q * y1
    return a, x0, y0