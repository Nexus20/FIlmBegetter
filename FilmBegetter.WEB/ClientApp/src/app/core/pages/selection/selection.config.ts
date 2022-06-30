export const CSelectionPage = {
    inputs: {
        searchInput: {
            placeholder: "Search Movies or TV Shows",
            icon: "search-normal",
            type: "default" as "default",
            isdisabled: false
        }
    },
    content: {
        findMovie: "Find movie".split('')
    },
    bestOptions: {
        label: "Best options",
        direction: "horizontal" as 'horizontal',
    },
    topMoviesOfTheYear: {
        label: "Top movies of the " + new Date().getFullYear() + " year",
        direction: "horizontal" as 'horizontal',
    },
    bestMoviesOfAllTime: {
        label: "The best movies of all time",
        direction: "horizontal" as 'horizontal',
    },
    bestComedies: {
        label: "The funniest comedies",
        direction: "horizontal" as 'horizontal',
    },
    bestHorrors: {
        label: "The scariest horrors",
        direction: "horizontal" as 'horizontal',
    },
    bestForChildren: {
        label: "Best for children",
        direction: "horizontal" as 'horizontal',
    },
    bestMysteries: {
        label: "The most mysterious",
        direction: "horizontal" as 'horizontal',
    },
    mightLike: {
        label: "You might like"
    },
    moreMovies: {
        text: "More interesting movies can be found in the catalog",
        button: {
            type: 'default' as 'default',
            size: 'default' as 'default',
            text: 'Catalog',
            disabled: false,
            href: 'catalog',
        }
    }
}
