<template>
    <div>
        <div :class="inputClass + ' tags-input'">
            <!--<span class="badge badge-pill badge-light"-->
            <!-- +{(UrlList.filter(badge).length > 0)?'badge-light-red':'badge-light-blue'} -->
            <span v-for="(badge, index) in tagBadges"
                  :class="'badge badge-pill ' + ((UrlList.length > 0 && badge.length > 0) ? ( (UrlList.filter(function (obj) { return obj.indexOf(badge) > -1 }).length > 0 && (selectedRule == 'contains' || validUrl(badge))) ? 'badge-light-blue' : (  (selectedRule == 'contains' || UrlList.filter(function (obj) { return obj.indexOf(parseUrl(badge)) > -1 }).length > 0) && (selectedRule == 'contains' || validUrl(badge)) ) ? 'badge-light-orange' : 'badge-light-red') : 'badge-light-blue')"
                  :key="index">
                <span v-html="badge"></span>

                <i href="#" class="tags-input-remove" :hidden="(!hiddenRemove)?hidden:''" @click.prevent="removeTag(index)"></i>
            </span>

            <input type="text"
                   :placeholder="placeholder"
                   :hidden="(!disabled)?hidden:''"
                   :disabled="disabled"
                   :selectedRule="selectedRule"
                   v-model="input"
                   @keydown.enter.prevent="tagFromInput"
                   @keydown.8="removeLastTag"
                   @keydown.down="nextSearchResult"
                   @keydown.up="prevSearchResult"
                   @keyup.esc="ignoreSearchResults"
                   @keyup="searchTag"
                   @value="tags"
                   >

            <input type="hidden" v-if="elementId"
                   :name="elementId"
                   :id="elementId"
                   v-model="hiddenInput">
        </div>

        <p v-show="searchResults.length" class="typeahead">
            <span v-for="(tag, index) in searchResults"
                :key="index"
                v-text="tag.text"
                @click="tagFromSearch(tag)"
                class="badge"
                v-bind:class="{
                    'badge-primary': index == searchSelection,
                    'badge-dark': index != searchSelection
                }"></span>
        </p>
    </div>
</template>

<script>
    import Vue from 'vue';
    import VueCookie from 'vue-cookie';

    Vue.use(VueCookie);

    const parseUrl = require("parse-url");

export default {
    props: {
        elementId: String,
        selectedRule: String,
        inputClass: {
            type: String,
            default: 'tags-input-default-class'
        },

        existingTags: {
            type: Object,
            default: () => {
                return {};
            }
        },

        value: {
            type: [Array, String],
            default: () => {
                return [];
            }
        },

        disabled: {
            type: Boolean,
            default: false
        },

        hiddenRemove: {
            type: Boolean,
            default: false
        },

        typeahead: {
            type: Boolean,
            default: false
        },

        typeaheadActivationThreshold: {
            type: Number,
            default: 1
        },

        typeaheadMaxResults: {
            type: Number,
            default: 0
        },

        placeholder: {
            type: String,
            default: 'Add a tag'
        },

        limit: {
            type: Number,
            default: 0
        },

        onlyExistingTags: {
            type: Boolean,
            default: false
        },

        deleteOnBackspace: {
            type: Boolean,
            default: true
        },

        allowDuplicates: {
            type: Boolean,
            default: false
        },
        
        validate: {
            type: Function,
            default: () => true
        }
    },

    data() {
        return {
            adminAccess: false,
            userUid: "none",

            badgeId: 0,
            tagBadges: [],
            tags: [],
            UrlList:[],

            input: '',
            oldInput: '',
            hiddenInput: '',

            searchResults: [],
            searchSelection: 0,
        };
    },

        created() {
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/get_urls",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                }).done(function (dataUrls) {
                    if (dataUrls.urls != undefined) {
                        dataUrls.urls.forEach(function (urls) {
                            that.UrlList.push(urls)
                        });
                    }
                })
        this.tagsFromValue();
    },

    watch: {
        tags() {
            // Updating the hidden input
            this.hiddenInput = this.tags.join(',');

            // Update the bound v-model value
            this.$emit('input', this.tags);
        },

        value() {
            this.tagsFromValue();
        }
    },

    methods: {
        parseUrl(parsUrl) {
            return parseUrl(parsUrl, true).resource;
        },
        validUrl(valUrl) {
            if (/^[a-zA-Z0-9][a-zA-Z0-9-]{1,61}[a-zA-Z0-9]\.[a-zA-Z]{2,}$/.test(parseUrl(valUrl, true).resource) || /^[a-zA-Z0-9-]{0,61}[a-zA-Z0-9]\.[a-zA-Z0-9-]{1,61}[a-zA-Z0-9]\.[a-zA-Z]{1,}$/.test(parseUrl(valUrl, true).resource)) {
                return true;
            } else {
                return false;
            }
        },
        tagFromInput(e) {
        // If we're choosing a tag from the search results
        if (this.searchResults.length && this.searchSelection >= 0) {
            this.tagFromSearch(this.searchResults[this.searchSelection]);

            this.input = '';
        } else {
            // If we're adding an unexisting tag
            let text = this.input.trim();

            //remove last character
            text = text.toLowerCase();
            
            if (text.slice(-1) == "/") {
                text = text.slice(0, -1);
            }
           

            // If the new tag is not an empty string and passes validation
            if (!this.onlyExistingTags && text.length && this.validate(text)) {
                this.input = '';

                // Determine the tag's slug and text depending on if the tag exists
                // on the site already or not
                let slug = this.makeSlug(text);
                let existingTag = this.existingTags[slug];

                slug = existingTag ? slug : text;
                text = existingTag ? existingTag : text;

                this.addTag(slug, text);
            }
        }
    },

    tagFromSearch(tag) {
        this.searchResults = [];
        this.input = '';
        this.oldInput = '';

        this.addTag(tag.slug, tag.text);
    },

    makeSlug(value) {
        return value.toLowerCase().replace(/\s/g, '-');
    },

        addTag(slug, text) {
            var that = this;
        // Check if the limit has been reached
        if (this.limit > 0 && this.tags.length >= this.limit) {
            return false;
        }

        // Attach the tag if it hasn't been attached yet
        if (!this.tagSelected(slug)) {
            this.tagBadges.push(text.replace(/\s/g, '&nbsp;'));
                this.tags.push(slug);
        }
    },

    removeLastTag(e) {
        if (!e.target.value.length && this.deleteOnBackspace) {
            this.removeTag(this.tags.length - 1);
        }
    },

    removeTag(index) {
        if (!this.disabled) {
            this.tags.splice(index, 1);
            this.tagBadges.splice(index, 1);
        }
    },

    searchTag(e) {
        if (this.typeahead === true) {
            if (this.oldInput != this.input) {
                this.searchResults = [];
                this.searchSelection = 0;
                let input = this.input.trim();

                if (input.length && input.length >= this.typeaheadActivationThreshold) {
                    for (let slug in this.existingTags) {
                        let text = this.existingTags[slug].toLowerCase();

                        if (text.search(input.toLowerCase()) > -1 && ! this.tagSelected(slug)) {
                            this.searchResults.push({ slug, text: this.existingTags[slug] });
                        }
                    }

                    // Sort the search results alphabetically
                    this.searchResults.sort((a, b) => {
                        if (a.text < b.text) return -1;
                        if (a.text > b.text) return 1;

                        return 0;
                    });

                    // Shorten Searchresults to desired length
                    if (this.typeaheadMaxResults > 0) {
                        this.searchResults = this.searchResults.slice(
                            0,
                            this.typeaheadMaxResults
                        );
                    }
                }

                this.oldInput = this.input;
            }
        }
    },

    nextSearchResult() {
        if (this.searchSelection + 1 <= this.searchResults.length - 1) {
            this.searchSelection++;
        }
    },

    prevSearchResult() {
        if (this.searchSelection > 0) {
            this.searchSelection--;
        }
    },

    ignoreSearchResults() {
        this.searchResults = [];
        this.searchSelection = 0;
    },

    /**
    * Clear the list of selected tags
    */
    clearTags() {
        this.tags.splice(0, this.tags.length);
        this.tagBadges.splice(0, this.tagBadges.length);
    },

    /**
    * Replace the currently selected tags with the tags from the value
    */
    tagsFromValue() {
        if (this.value && this.value.length) {
            let tags = Array.isArray(this.value)
                ? this.value
                : this.value.split(',');

            if (this.tags == tags) {
                return;
            }

            this.clearTags();

            for (let slug of tags) {
                let existingTag = this.existingTags[slug];
                let text = existingTag ? existingTag : slug;

                this.addTag(slug, text);
            }
        } else {
            if (this.tags.length == 0) {
                return;
            }

            this.clearTags();
        }
    },

    /**
    * Check if the tag with the provided slug is already selected
    */
    tagSelected(slug) {
        if (this.allowDuplicates) {
            return false;
        }

        if (! slug) {
            return false;
        }

        let searchSlug = this.makeSlug(slug);
        let found = this.tags.find((value) => {
            return searchSlug == this.makeSlug(value);
        });

        return !! found;
    }
    }
}
</script>

<style lang="css">
    .tags-input {
        display: contents; 
        flex-wrap: wrap;
        align-items: center;
    }

        .tags-input input {
            flex: 1;
            background: transparent;
            border: none;
            vertical-align: -webkit-baseline-middle;
            margin-top: 3px;
        }

        .tags-input span {
            margin-right: 0.3rem;
            margin-bottom: 0.2rem;
            vertical-align: text-top;
            max-width: -webkit-fill-available;
            overflow-wrap: anywhere;
            padding: 2px 10px 2px 10px;
        }

.typeahead > span {
    cursor: pointer;
    margin-right: 0.3rem;
}
</style>
