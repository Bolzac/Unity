## About Repositery
monkeyType repositery is my first attempt to create a project with genetic algorithm.

### What is Genetic Algorithm?
It is an algorithm inspired from nature, especially from evolution. In evolution we have three key subject.
- Heredity
- Variation
- Selection

Heredity is a mechanism which allows members of population to pass their genes to next generation. We know it as a reproduction.
Variation is variety of members' genes of a population. Thanks to this mechanism every generation is different from previous one and we can see changes between generations in a good way or a bad way.
Selection says that not all members in a population have the opportunity to pass their genes to next generation. As we can see in nature, the one who survive in enviremont conditions able to survive and have a time to reproduction.
This three key subject is bonded each other strongly and we can't think that one is not exists. As we can see in a habitat, populations are getting better at surviving in every pass to the next generation.

We got that logic, to make the first populations members better with try every possibility to survive. That's why evolution goes very slow. We are going to simulate it in a project. We are going to think about a classic problem named "Infinite monkey theorem".
This theorem says that if we let a monkey type on keyboard, it has a chance to write works of William Shakespeare. Like this theorem, we are going to try to write "to be or not to be" randomly in our project.

1. Create a population of N randomly generated elements with a virtual DNA. (Variety Step)
2. Choose the members who are going to pass their genes to next generation. (Selection Step)
  1. Evaluate Fitness
    - This is where you determine the fitness of members compare to target.
    - For example, if we try to write the word of "cat" and if the population's members are "hut", "car", and "box" they have a value of fitness.
| DNA | Fitness Value |
|----:|---------------|
|hut|1/3|
|car|2/3|
|box|0|
| Rank | Languages |
|-----:|-----------|
|     1| Javascript|
|     2| Python    |
|     3| SQL       |
  2. Create a Mating Pool
    - In this step we are going to create a collection with type List<type>. In this list there is going to be our members to pass their genes to next generation. We are going to use "Probabilistic Method". In this method, our list size going to be total fitness of all members (we are going to product fitness values with 100 to get integer values from percentages). Then put the member fitness of members x 100 times in list. After that, we are going to select randomly from list.
3. Reproduction
