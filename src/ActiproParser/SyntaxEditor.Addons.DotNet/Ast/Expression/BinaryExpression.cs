using System;

namespace ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast {

	/// <summary>
	/// Represents a binary expression.
	/// </summary>
	public class BinaryExpression : Expression {

		private OperatorType	operatorType;
		
		/// <summary>
		/// Gets the context ID for a left expression AST node.
		/// </summary>
		/// <value>The context ID for a left expression AST node.</value>
		public const byte LeftExpressionContextID = Expression.ExpressionContextIDBase;
		
		/// <summary>
		/// Gets the context ID for a right expression AST node.
		/// </summary>
		/// <value>The context ID for a right expression AST node.</value>
		public const byte RightExpressionContextID = Expression.ExpressionContextIDBase + 1;
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes a new instance of the <c>BinaryExpression</c> class. 
		/// </summary>
		/// <param name="operatorType">An <see cref="OperatorType"/> indicating the binary operator type.</param>
		/// <param name="leftExpression">The left <see cref="Expression"/> affected by the unary operator.</param>
		/// <param name="rightExpression">The right <see cref="Expression"/> affected by the unary operator.</param>
		/// <param name="textRange">The <see cref="TextRange"/> of the expression.</param>
		public BinaryExpression(OperatorType operatorType, Expression leftExpression, Expression rightExpression, TextRange textRange) {
			// Initialize parameters
			this.operatorType		= operatorType;
			this.LeftExpression		= leftExpression;
			this.RightExpression	= rightExpression;
			this.StartOffset		= textRange.StartOffset;
			this.EndOffset			= textRange.EndOffset;
		}
		
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
		/// Gets or sets the left <see cref="Expression"/> affected by the binary operator.
		/// </summary>
		/// <value>The left <see cref="Expression"/> affected by the binary operator.</value>
		public Expression LeftExpression {
			get {
				return this.GetChildNode(BinaryExpression.LeftExpressionContextID) as Expression;
			}
			set {
				this.ChildNodes.Replace(value, BinaryExpression.LeftExpressionContextID);
			}
		}
		
		/// <summary>
		/// Gets the <see cref="DotNetNodeType"/> that identifies the type of node.
		/// </summary>
		/// <value>The <see cref="DotNetNodeType"/> that identifies the type of node.</value>
		public override DotNetNodeType NodeType { 
			get {
				return DotNetNodeType.BinaryExpression;
			}
		}

		/// <summary>
		/// Gets or sets an <see cref="OperatorType"/> indicating the binary operator type.
		/// </summary>
		/// <value>An <see cref="OperatorType"/> indicating the binary operator type.</value>
		public OperatorType OperatorType {
			get {
				return operatorType;
			}
			set {
				operatorType = value;
			}
		}

		/// <summary>
		/// Gets or sets the right <see cref="Expression"/> affected by the binary operator.
		/// </summary>
		/// <value>The right <see cref="Expression"/> affected by the binary operator.</value>
		public Expression RightExpression {
			get {
				return this.GetChildNode(BinaryExpression.RightExpressionContextID) as Expression;
			}
			set {
				this.ChildNodes.Replace(value, BinaryExpression.RightExpressionContextID);
			}
		}


	}
}