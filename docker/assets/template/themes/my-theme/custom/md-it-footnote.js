// The following must be added to the custom header in the BookStack configuration.
// 
// <script src="https://cdnjs.cloudflare.com/ajax/libs/markdown-it-footnote/4.0.0/markdown-it-footnote.min.js" integrity="sha512-giw4jyv75ngVba/TWbP9ouANTIA67sJoNWUvOW8ogr1NqByolnc+jbIwj+yAJ0eF/5SLfwv8IZoIVu8bN5XWRw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
// <script src="/custom/md-it-footnote.js"></script>


window.addEventListener('editor-markdown::setup', function(event)
{
    const mdIt = event.detail.markdownIt;
    // Footnote
    mdIt.use(window.markdownitFootnote);
    mdIt.renderer.rules.footnote_caption = (tokens, idx/*, options, env, slf*/) =>
    {
        var n = Number(tokens[idx].meta.id + 1).toString();
        if (tokens[idx].meta.subId > 0) { n += ':' + tokens[idx].meta.subId; }
        return n;
    };
    // Autolink
    mdIt.options.linkify = true;
});
