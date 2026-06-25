## Keeping your repo clean (build artifacts)

This repo now has a `.gitignore` at the root. It tells git to ignore the folders
your computer auto-generates (`bin/`, `obj/`, `.vs/`). Don't delete it.

A correct homework commit is a handful of `.cs` and project files. Before every
commit, run `git status` -- if you see `bin/`, `obj/`, `.vs/`, or `.dll` files,
STOP, something is wrong.

If you already committed those folders, untrack them once:

    git rm -r --cached bin obj .vs
    git commit -m "Remove build artifacts"
    git push

Never commit: `bin/`  `obj/`  `.vs/`  `*.user` -- they're machine-specific and
regenerated every build.
