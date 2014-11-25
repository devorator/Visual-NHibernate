using System;

namespace ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast {

	/// <summary>
	/// Represents a query expression ordering.
	/// </summary>
	public class Ordering : AstNode {

		private OrderingDirection		direction		= OrderingDirection.Ascending;

		/// <summary>
		/// Gets the context ID for the expression AST node.
		/// </summary>
		/// <value>The context ID for the expression AST node.</value>
		public const byte ExpressionContextID = AstNode.AstNodeContextIDBase;
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes a new instance of the <c>Ordering</c> class. 
		/// </summary>
		public Ordering() {}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Accepts the specified visitor for visiting this node.
		/// </summary>
		/// <param name="visitor">The visitor to accept.</param>
		/// <remarks>This method is part of the visitor design pattern implementation.</remarks>
		protected override void AcceptCore(AstVisitor visitor) {
			if (visitor.OnVisiting(this)) {
				// Visit children
				if (this.ChildNodeCount > 0)
					this.AcceptChildren(visitor, this.ChildNodes);
			}
			visitor.OnVisited(this);
		}
	
		/// <summary>
		/// Gets or sets the sort order.
		/// </summary>
		/// <value>The sort order.</value>
		public OrderingDirection Direction {
			get {
				return direction;
			}
			set {
				direction = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the condition <see cref="Expression"/> by which to order.
		/// </summary>
		/// <value>The condition <see cref="Expression"/> by which to order.</value>
		public Expression Expression {
			get {
				return this.GetChildNode(Ordering.ExpressionContextID) as Expression;
			}
			set {
				this.ChildNodes.Replace(value, Ordering.ExpressionContextID);
			}
		}
		
		/// <summary>
		/// Gets the <see cref="DotNetNodeType"/> that identifies the type of node.
		/// </summary>
		/// <value>The <see cref="DotNetNodeType"/> that identifies the type of node.</value>
		public override DotNetNodeType NodeType { 
			get {
				return DotNetNodeType.Ordering;
			}
		}
		
	}
}