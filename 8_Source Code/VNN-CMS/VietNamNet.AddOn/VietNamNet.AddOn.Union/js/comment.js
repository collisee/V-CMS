var tplComments = new AP.Core.JS.Template({
    id: 'tplComments',
    template: ['<div>',
               '<p class="cmnt-title">{FullName} - <a href="mailto:{Email}">{Email}</a></p>',
               '<div class="cmnt-content">{Comment}</div>',
               '</div>'].join('')
});

AP.Core.JS.TemplateManager.add(tplComments);
