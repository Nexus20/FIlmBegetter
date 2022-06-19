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
