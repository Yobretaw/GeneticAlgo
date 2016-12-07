module Random

open System
open System.Threading

let private random: ThreadLocal<System.Random> =
    let seed = ref Environment.TickCount
    new ThreadLocal<Random>(fun () -> new Random(Interlocked.Increment(seed)))

let Random = random.Value

let GetRandomBytes count =
    let bytes = Array.zeroCreate count
    Random.NextBytes bytes
    bytes
    // Array.create 4 2uy

let GetRandomByte =
    byte(Random.Next 256)

let GetRandomByteInRange low high =
    byte(Random.Next(low high))