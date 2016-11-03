# SRH
SRH Project - ProgII

Git basic commands through console 

To add new files to the repository or add changed files to staged area:

$ git add <files>

To commit them:

$ git commit

To commit unstaged but changed files:

$ git commit -a

To push to a repository (say origin):

$ git push origin

To push only one of your branches (say master):

$ git push origin master

To fetch the contents of another repository (say origin):

$ git fetch origin

To fetch only one of the branches (say master):

$ git fetch origin master

To merge a branch with the current branch (say other_branch):

$ git merge other_branch

Note that origin/master is the name of the branch you fetched in the previous step from origin. Therefore, updating your master branch from origin is done by:

$ git fetch origin master
$ git merge origin/master
