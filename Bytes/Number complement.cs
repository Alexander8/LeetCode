public int FindComplement(int num) 
{
    var mask = num;
    
    mask |= mask >> 1;
    mask |= mask >> 2;
    mask |= mask >> 4;
    mask |= mask >> 8;
    mask |= mask >> 16;
    
    return ~num & mask;
}


// #2
public int FindComplement(int num) 
{
    var mask = 0;
    var wasOne = false;
    for (var i = 31; i >= 0; --i)
    {
        if (!wasOne && (num & (1 << i)) != 0)
            wasOne = true;

        if (wasOne)
            mask |= 1 << i;
    }        

    return ~num & mask;
}