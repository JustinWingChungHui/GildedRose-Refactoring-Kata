# Gilded Rose Change

## Building
Code can be built using the standard Visual Studio Build functionality.

It will output a files to the bin/Release folder.

```
csharp.exe
```
Can be opened to start the program.


## Summary of changes
This is the summary of the work done

### Fixing existing tests
1. Test Foo was fixed so that it passed
2. **ApprovalTest.ThirtyDays.approved.txt** was generated from existing output so that the approval test passed

### Refactoring existing code
I decided that the existing code was too difficult to comprehend without the Requirements.

I refactored the code so that each item rule was separated into it's own method that could be tested within the **GildedRose** class.  

The existing tests were run to ensure the same output as before.

Tests for each item were added to the **GildedRoseTest** class.


### Adding Conjured Items
A new method to handle the degradation of conjured items was created in the **GildedRose** class; and accompanying unit tests were created in the **GildedRoseTest** class.

**ApprovalTest.ThirtyDays.approved.txt** was edited and the approval test was re-run to check everything still worked as expected.


