export function getContentItem(contentId, content) {
    let result = ""
    content.map(x => {
        if (contentId === x.contentId) {
            result = x.value;
        }
    });
    return result;
}
