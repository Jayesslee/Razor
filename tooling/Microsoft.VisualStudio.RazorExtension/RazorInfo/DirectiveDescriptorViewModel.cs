﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#if RAZOR_EXTENSION_DEVELOPER_MODE
using System.Text;
using Microsoft.AspNetCore.Razor.Language;

namespace Microsoft.VisualStudio.RazorExtension.RazorInfo
{
    public class DirectiveDescriptorViewModel : NotifyPropertyChanged
    {
        private readonly DirectiveDescriptor _directive;

        internal DirectiveDescriptorViewModel(DirectiveDescriptor directive)
        {
            _directive = directive;

            var builder = new StringBuilder();
            builder.Append("@");
            builder.Append(_directive.Directive);

            foreach (var token in _directive.Tokens)
            {
                builder.Append("(");
                builder.Append(token.Kind.ToString());
                builder.Append(")");
            }

            if (directive.Kind == DirectiveKind.CodeBlock || directive.Kind == DirectiveKind.RazorBlock)
            {
                builder.Append("{ ... }");
            }

            DisplayText = builder.ToString();
        }

        public string DisplayText { get; }

        public string Name => _directive.Directive;
    }
}
#endif