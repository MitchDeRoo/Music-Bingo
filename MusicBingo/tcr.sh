#!/bin/bash

# Function to run tests
run_tests() {
    dotnet test --no-build --verbosity minimal
}

# Function to commit changes
commit_changes() {
    git add .
    git commit -m "TCR: Test passed, committing changes."
}

# Function to revert changes
revert_changes() {
    git reset --hard
}

# Run tests
run_tests

# Check if the tests passed
if [ $? -eq 0 ]; then
    echo "Tests passed. Committing changes."
    commit_changes
else
    echo "Tests failed. Reverting changes."
    revert_changes
fi

