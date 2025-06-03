# .Net Project layout

Unlike other technologies, .Net recommends the separation of code and tests by placing them in different .Net Projects that correspond to different directories.

## Projects layouts

The two most common approaches to project files organization are:

### Root-level separation (src/tests)

```sh
ProjectRoot/
├── src/
│   └── YourApi.API/
└── tests/
    └── YourApi.Tests/
```

Advantages:

- Clear, immediate visual separation between production and test code
- Easier to exclude all tests from deployment by ignoring the entire tests folder
- Makes it simple to apply different build configurations or CI/CD pipelines
- Common in many open-source projects, making it familiar to contributors
- Better scalability when adding multiple test projects (unit, integration, performance)
- Cleaner root directory structure

### Tests alongside source code

```src
ProjectRoot/
└── src/
    ├── YourApi.API/
    └── YourApi.Tests/
```

Advantages:

- Closer proximity between tests and the code they're testing
- Easier to navigate between source and test files in IDEs
- More intuitive for smaller projects
- Follows the principle of keeping related files close together
- Can make it easier to maintain test and source code synchronization
- Better suited for feature-based organization

### Conclusion

The root-level separation tends to be more popular in larger enterprise projects, while the alongside approach is often seen in smaller, more focused projects. Your choice might depend on factors like:

Team size and preferences

- Project scale
- Build and deployment requirements
- Whether you have multiple types of tests
- Your source control branching strategy

Both approaches work well with modern CI/CD pipelines and build tools, so it often comes down to team preference and project requirements. 

