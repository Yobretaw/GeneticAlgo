module Random

open System
open System.Threading

let private generator: ThreadLocal<System.Random> =
    let seed = ref Environment.TickCount
    new ThreadLocal<Random>(fun () -> new Random(Interlocked.Increment(seed)))

let GetRandomBytes count =
    let bytes = Array.zeroCreate count
    generator.Value.NextBytes(bytes)
    bytes